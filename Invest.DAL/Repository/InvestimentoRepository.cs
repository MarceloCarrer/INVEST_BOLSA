using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Repository
{
    public class InvestimentoRepository : RepositoryGeneric<Investimento>, IInvestimentoRepository
    {
        private readonly Context _context;

        public InvestimentoRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Investimento> FiltrarInvestimentos(int ano)
        {
            try
            {
                return _context.Investimentos
                    .Where(i => i.Ano == ano);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Investimento> GetInvestimentoForUserId(string usuarioId)
        {
            try
            {
                return _context.Investimentos
                    .Where(t => t.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<double> GetInvestimentoTotalUserId(string usuarioId)
        {
            try
            {
                return await _context.Investimentos.Where(i => i.UsuarioId == usuarioId).SumAsync(i => i.Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
