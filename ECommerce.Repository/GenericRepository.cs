using App.Data.MyDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ECommerceDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            throw new KeyNotFoundException($"Entity {typeof(T).Name} with ID {id} not found.");

        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                return entity;
            }
            throw new KeyNotFoundException($"Entity {typeof(T).Name} with ID {id} not found.");
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
