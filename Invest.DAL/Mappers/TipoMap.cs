using Invest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Mappers
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(t => t.TipoId);

            builder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.Nome).IsUnique();

            builder.Property(t => t.Sigla).IsRequired().HasMaxLength(10);
            builder.HasIndex(t => t.Sigla).IsUnique();

            builder.Property(t => t.Codigo).IsRequired();

            builder.HasData(
                    new Tipo
                    {
                        TipoId = 1,
                        Nome = "ORDINÁRIA",
                        Sigla = "ON",
                        Codigo = 3
                    },
                    new Tipo
                    {
                        TipoId = 2,
                        Nome = "PREFERENCIAL",
                        Sigla = "PN",
                        Codigo = 4
                    },
                    new Tipo
                    {
                        TipoId = 3,
                        Nome = "PREFERÊNCIAIS CLASSE A",
                        Sigla = "PNA",
                        Codigo = 5
                    },
                    new Tipo
                    {
                        TipoId = 4,
                        Nome = "PREFERÊNCIAIS CLASSE B",
                        Sigla = "PNB",
                        Codigo = 6
                    },
                    new Tipo
                    {
                        TipoId = 5,
                        Nome = "PREFERÊNCIAIS CLASSE C",
                        Sigla = "PNC",
                        Codigo = 7
                    },
                    new Tipo
                    {
                        TipoId = 6,
                        Nome = "PREFERÊNCIAIS CLASSE D",
                        Sigla = "PND",
                        Codigo = 8
                    },
                    new Tipo
                    {
                        TipoId = 7,
                        Nome = "BDR",
                        Sigla = "BDR",
                        Codigo = 11
                    },
                    new Tipo
                    {
                        TipoId = 8,
                        Nome = "UNITS",
                        Sigla = "UNITS",
                        Codigo = 11
                    });

            builder.ToTable("Tipos");
        }
    }
}
