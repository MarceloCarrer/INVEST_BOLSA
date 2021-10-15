using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.DAL.Repository
{
    public class MesRepository : RepositoryGeneric<Mes>, IMesRepository
    {
        private readonly Context _context;

        public MesRepository(Context context) : base(context)
        {
            _context = context;
        }
         
        public IQueryable<Mes> GetAllMeses()
        {
            try
            {
                return _context.Meses
                    .OrderBy(m => m.MesId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
