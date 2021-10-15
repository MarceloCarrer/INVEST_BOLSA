using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Repository
{
    public class TipoRepository : RepositoryGeneric<Tipo>, ITipoRepository
    {
        private readonly Context _context;

        public TipoRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Tipo> FiltrarTipos(string nomeTipo)
        {
            try
            {
                var entity = _context.Tipos.Where(t => t.Nome.Contains(nomeTipo));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
