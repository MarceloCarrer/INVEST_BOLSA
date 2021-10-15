using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Interfaces
{
    public interface IMesRepository : IRepositoryGeneric<Mes>
    {
        IQueryable<Mes> GetAllMeses();
    }
}
