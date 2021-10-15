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
    public class TransacaoRepository : RepositoryGeneric<Transacao>, ITransacaoRepository
    {
        private readonly Context _context;

        public TransacaoRepository(Context context) : base(context)
        {
            _context = context;
        }

        public void DeleteTransacao(IEnumerable<Transacao> transacoes)
        {
            try
            {
                _context.Transacoes.RemoveRange(transacoes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transacao>> GetTransacaoForAtivoId(int ativoId)
        {
            try
            {
                return await _context.Transacoes
                    .Where(t => t.AtivoId == ativoId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Transacao> GetTransacaoForUserId(string usuarioId)
        {
            try
            {
                return _context.Transacoes
                    .Include(t => t.Ativo)
                    .Include(t => t.Tipo)
                    .Where(t => t.UsuarioId == usuarioId)
                    .OrderByDescending(t => t.Vendido == false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Transacao> FiltrarTransacoes(string nomeAtivo)
        {
            try
            {
                return _context.Transacoes
                    .Include(t => t.Ativo)
                    .Include(t => t.Tipo)
                    .Where(t => t.Ativo.Sigla.Contains(nomeAtivo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Transacao> FiltrarVendidos(bool vendido)
        {
            try
            {
                return _context.Transacoes
                    .Include(t => t.Ativo)
                    .Include(t => t.Tipo)
                    .Where(t => t.Vendido == vendido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<double> GetTransacaoTotalUserId(string usuarioId)
        {
            try
            {
                return(double) await _context.Transacoes.Where(t => t.UsuarioId == usuarioId).SumAsync(t => (t.ValorVenda * t.QtdVenda) - (t.ValorCompra * t.QtdCompra));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
