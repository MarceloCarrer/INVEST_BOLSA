using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    class InvestimentoMap : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.HasKey(i => i.InvestimentoId);

            builder.Property(i => i.Valor).IsRequired();

            builder.Property(i => i.Dia).IsRequired();

            builder.Property(i => i.Ano).IsRequired();

            builder.HasOne(i => i.Mes).WithMany(i => i.Investimentos).HasForeignKey(i => i.MesId).IsRequired();

            builder.HasOne(i => i.Usuario).WithMany(i => i.Investimentos).HasForeignKey(i => i.UsuarioId).IsRequired();

            builder.ToTable("Investimentos");
        }
    }
}
