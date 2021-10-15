using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Interfaces
{
    public interface IAtivoRepository : IRepositoryGeneric<Ativo>
    {
        IQueryable<Ativo> GetAtivosForUserId(string usuarioId);

        IQueryable<Ativo> FiltrarAtivos(string nomeAtivo);
    }
}
