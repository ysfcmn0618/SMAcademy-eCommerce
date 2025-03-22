using App.Admin.Models.CategoryViewModels;
using App.Admin.Models.CommentViewModel;
using App.Admin.Models.ProductViewModels;
using App.Data.Entities;
using AutoMapper;


namespace App.Admin.Mapping
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<SaveCategoryViewModel, CategoryEntity>()
                 .ReverseMap();
            CreateMap<ProductEntity, ProductModel>()
                .ReverseMap();
            CreateMap<ProductEntity, ProductEditModel>()
                .ReverseMap();
            CreateMap<ProductCommentEntity, CommentViewModel>()
                .ReverseMap();

        }
    }
}
