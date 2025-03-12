using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class RelBlogTagService : IRelBlogTagService
    {
        private readonly IGenericRepository<RelBlogTagEntity> _relBlogTagService;
        public RelBlogTagService(IGenericRepository<RelBlogTagEntity> genericRepository)
        {
            _relBlogTagService = genericRepository;
        }
        public async Task AddRelBlogTag(RelBlogTagEntity relBlogTag)
        {
            await _relBlogTagService.Add(relBlogTag);
        }

        public async Task DeleteBlogTag(int id)
        {
            await _relBlogTagService.Delete(id);
        }

        public async Task<IEnumerable<RelBlogTagEntity>> GetBlogTags()
        {
            return await _relBlogTagService.GetAll();
        }

        public async Task<RelBlogTagEntity> GetRelBlogTagEntity(int id)
        {
            return await _relBlogTagService.GetById(id);
        }

        public async Task UpdaterelBlogTag(RelBlogTagEntity relBlogTag)
        {
            await _relBlogTagService.Update(relBlogTag);
        }
    }
}
