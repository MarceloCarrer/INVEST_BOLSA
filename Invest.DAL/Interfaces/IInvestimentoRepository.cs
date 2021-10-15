using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface IInvestimentoRepository : IRepositoryGeneric<Investimento>
    {
        IQueryable<Investimento> GetInvestimentoForUserId(string usuarioId);

        IQueryable<Investimento> FiltrarInvestimentos(int ano);

        Task<double> GetInvestimentoTotalUserId(string usuarioId);
    }
}
