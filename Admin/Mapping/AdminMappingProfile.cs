using App.Admin.Models.CategoryViewModels;
using App.Admin.Models.ProductViewModels;
using App.Data.Entities;
using AutoMapper;


namespace App.Admin.Mapping
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<CategoryModel, CategoryEntity>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<ProductEntity, ProductModel>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductEntity, ProductEditModel>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
