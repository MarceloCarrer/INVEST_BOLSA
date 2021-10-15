using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface ITransacaoRepository : IRepositoryGeneric<Transacao>
    {
        IQueryable<Transacao> GetTransacaoForUserId(string usuarioId);

        void DeleteTransacao(IEnumerable<Transacao> transacoes);

        Task<IEnumerable<Transacao>> GetTransacaoForAtivoId(int ativoId);

        IQueryable<Transacao> FiltrarTransacoes(string nomeAtivo);

        IQueryable<Transacao> FiltrarVendidos(bool vendido);

        Task<double> GetTransacaoTotalUserId(string usuarioId);
    }
}
