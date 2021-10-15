using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(t => t.TransacaoId);

            builder.Property(t => t.DiaCompra).IsRequired();

            builder.HasOne(t => t.Mes).WithMany(t => t.Transacoes).HasForeignKey(t => t.MesIdCompra).IsRequired();

            builder.Property(t => t.AnoCompra).IsRequired();

            builder.Property(t => t.QtdCompra).IsRequired();

            builder.Property(t => t.ValorCompra).IsRequired();


            builder.Property(t => t.DiaVenda);

            builder.HasOne(t => t.Mes).WithMany(t => t.Transacoes).HasForeignKey(t => t.MesIdVenda);

            builder.Property(t => t.AnoVenda);

            builder.Property(t => t.QtdVenda);

            builder.Property(t => t.ValorVenda);


            builder.Property(t => t.Vendido);


            builder.HasOne(t => t.Usuario).WithMany(t => t.Transacoes).HasForeignKey(t => t.UsuarioId).IsRequired();

            builder.HasOne(t => t.Ativo).WithMany(t => t.Transacoes).HasForeignKey(t => t.AtivoId).IsRequired();

            builder.HasOne(t => t.Tipo).WithMany(t => t.Transacoes).HasForeignKey(t => t.TipoId).IsRequired();

            builder.ToTable("Transacoes");
        }
    }
}
