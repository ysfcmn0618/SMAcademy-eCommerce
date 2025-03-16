using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
