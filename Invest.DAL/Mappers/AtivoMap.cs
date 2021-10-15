using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    public class AtivoMap : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.HasKey(a => a.AtivoId);

            builder.Property(a => a.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Nome).IsUnique();

            builder.Property(a => a.Sigla).IsRequired().HasMaxLength(4);
            builder.HasIndex(a => a.Sigla).IsUnique();

            builder.Property(a => a.Setor).IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.Transacoes);

            builder.HasOne(a => a.Usuario).WithMany(a => a.Ativos).HasForeignKey(a => a.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Transacoes).WithOne(a => a.Ativo);            

            builder.ToTable("Ativos");
        }
    }
}
