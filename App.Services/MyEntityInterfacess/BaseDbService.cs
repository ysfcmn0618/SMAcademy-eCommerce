using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public class BaseDbService<T> : IBaseServiceInterface<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public BaseDbService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task Add(T addEntity)
        {
            await _repository.Add(addEntity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
          return  await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(T updateEntity)
        {
            await _repository.Update(updateEntity);
        }
        // Eager Loading - Tüm verileri ilişkileriyle birlikte getir
        public async Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includes)
        {
            return await _repository.GetAllIncludingAsync(includes);
        }

        // Eager Loading - ID'ye göre tek bir veriyi ilişkileriyle birlikte getir
        public async Task<T?> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            return await _repository.GetByIdIncludingAsync(id, includes);
        }
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }
    }
}
