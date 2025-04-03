using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

 
}
