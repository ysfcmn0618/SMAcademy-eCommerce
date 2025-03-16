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
    public class CategoryService : BaseDbService<CategoryEntity>
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        public CategoryService(IGenericRepository<CategoryEntity> categoryRepository):base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
    }
}
