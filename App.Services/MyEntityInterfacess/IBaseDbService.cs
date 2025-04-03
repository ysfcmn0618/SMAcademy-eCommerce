using App.Data.Entities;
using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IBaseDbService<T> where T : class
    {
        Task Add(T addEntity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T updateEntity);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }

 
}
