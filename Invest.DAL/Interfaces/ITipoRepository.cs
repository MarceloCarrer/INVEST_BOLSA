using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface ITipoRepository : IRepositoryGeneric<Tipo>
    {
        IQueryable<Tipo> FiltrarTipos(string nomeTipo);
    }
}
