using Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Repository
{
    public class GraficoRepository : IGraficoRepository
    {
        private readonly Context _context;

        public GraficoRepository(Context context)
        {
            _context = context;
        }

        public object GetComprasForUserId(string usuarioId, int ano)
        {
            try
            {
                return _context.Transacoes
                    .Where(t => t.UsuarioId == usuarioId && t.AnoCompra == ano)
                    .OrderBy(t => t.MesIdCompra)
                    .GroupBy(t => t.MesIdCompra)
                    .Select(t => new
                    {
                        MesId = t.Key,
                        Valores = t.Sum(v => v.ValorCompra * v.QtdCompra)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetVendasForUserId(string usuarioId, int ano)
        {
            try
            {
                return _context.Transacoes
                    .Where(t => t.UsuarioId == usuarioId && t.AnoVenda == ano)
                    .OrderBy(t => t.MesIdVenda)
                    .GroupBy(t => t.MesIdVenda)
                    .Select(t => new
                    {
                        MesId = t.Key,
                        Valores = t.Sum(v => v.ValorVenda * v.QtdVenda)
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
