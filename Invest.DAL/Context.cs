using Invest.BLL.Models;
using Invest.DAL.Mappers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL
{
    public class Context : IdentityDbContext<Usuario, Funcao, string>
    {
        public DbSet<Ativo> Ativos { get; set; }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Investimento> Investimentos { get; set; }

        public DbSet<Mes> Meses { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


        public Context(DbContextOptions<Context> opcoes) : base(opcoes) {   }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AtivoMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new InvestimentoMap());
            builder.ApplyConfiguration(new MesMap());
            builder.ApplyConfiguration(new TipoMap());
            builder.ApplyConfiguration(new TransacaoMap());
            builder.ApplyConfiguration(new UsuarioMap());
        }

    }
}
