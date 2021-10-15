using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.CPF).IsUnique();

            builder.HasMany(u => u.Ativos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Transacoes).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Investimentos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Usuarios");
        }
    }
}
