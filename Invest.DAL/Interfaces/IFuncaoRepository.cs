using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface IFuncaoRepository : IRepositoryGeneric<Funcao>
    {
        Task AddFuncao(Funcao funcao);

        Task UpdateFuncao(Funcao funcao);

        IQueryable<Funcao> FiltrarFuncao(string nomeFuncao);
    }
}
