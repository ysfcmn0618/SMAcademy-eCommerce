using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IRelBlogTagService
    {
        Task AddRelBlogTag(RelBlogTagEntity relBlogTag);
        Task<RelBlogTagEntity> GetRelBlogTagEntity(int id);
        Task<IEnumerable<RelBlogTagEntity>> GetBlogTags();
        Task UpdaterelBlogTag(RelBlogTagEntity relBlogTag);
        Task DeleteBlogTag(int id);
    }
}
