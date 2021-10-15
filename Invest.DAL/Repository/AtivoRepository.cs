using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Repository
{
    public class AtivoRepository : RepositoryGeneric<Ativo>, IAtivoRepository
    {
        private readonly Context _context;

        public AtivoRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Ativo> FiltrarAtivos(string nomeAtivo)
        {
            try
            {
                return _context.Ativos.Where(a => a.Nome.Contains(nomeAtivo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Ativo> GetAtivosForUserId(string usuarioId)
        {
            try
            {
                return _context.Ativos.Where(a => a.UsuarioId == usuarioId)
                    .OrderBy(a => a.Sigla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
