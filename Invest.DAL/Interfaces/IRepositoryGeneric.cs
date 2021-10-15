using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetId(int id);

        Task<TEntity> GetId(string id);

        Task Add(TEntity entity);

        Task Add(List<TEntity> entity);

        Task Update(TEntity entity);

        Task Delete(int id);

        Task Delete(string id);

        Task Delete(TEntity entity);

    }
}
