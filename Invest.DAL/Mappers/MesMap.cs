using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(m => m.MesId);

            builder.Property(m => m.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(m => m.Nome).IsUnique();

            builder.HasMany(m => m.Investimentos).WithOne(m => m.Mes);
            builder.HasMany(m => m.Transacoes).WithOne(m => m.Mes);

            builder.HasData(
                    new Mes
                    {
                        MesId = 1,
                        Nome = "JANEIRO"
                    },
                    new Mes
                    {
                        MesId = 2,
                        Nome = "FEVEREIRO"
                    },
                    new Mes
                    {
                        MesId = 3,
                        Nome = "MARÇO"
                    },
                    new Mes
                    {
                        MesId = 4,
                        Nome = "ABRIL"
                    },
                    new Mes
                    {
                        MesId = 5,
                        Nome = "MAIO"
                    },
                    new Mes
                    {
                        MesId = 6,
                        Nome = "JUNHO"
                    },
                    new Mes
                    {
                        MesId = 7,
                        Nome = "JULHO"
                    },
                    new Mes
                    {
                        MesId = 8,
                        Nome = "AGOSTO"
                    },
                    new Mes
                    {
                        MesId = 9,
                        Nome = "SETEMBRO"
                    },
                    new Mes
                    {
                        MesId = 10,
                        Nome = "OUTUBRO"
                    },
                    new Mes
                    {
                        MesId = 11,
                        Nome = "NOVEMBRO"
                    },
                    new Mes
                    {
                        MesId = 12,
                        Nome = "DEZEMBRO"
                    });

            builder.ToTable("Meses");
        }
    }
}
