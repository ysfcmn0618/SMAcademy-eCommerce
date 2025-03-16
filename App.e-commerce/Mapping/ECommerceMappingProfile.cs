using App.Data.Entities;
using App.eCommerce.Models.ViewModels.AuthViewModels;
using App.eCommerce.Models.ViewModels.BlogViewModels;
using App.eCommerce.Models.ViewModels.CategoryViewModels;
using App.eCommerce.Models.ViewModels.HomeViewModels;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using App.eCommerce.ViewComponents;
using AutoMapper;

namespace App.eCommerce.Mapping
{
    public class ECommerceMappingProfile : Profile
    {
        public ECommerceMappingProfile()
        {
            //UserEntity Mapping
            CreateMap<RegisterUserModel, UserEntity>().ReverseMap();
            CreateMap<ForgotPasswordViewModel, UserEntity>();
            CreateMap<LoginViewModel, UserEntity>();
            CreateMap<RegisterUserModel, UserEntity>().ReverseMap();
            CreateMap<RenevPasswordViewModel, UserEntity>();

            //ProductEntity Mapping
            CreateMap<ProductEntity, ProductViewComponentModel>().ReverseMap();
            CreateMap<ProductEntity, ProductListingViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount != null ? src.Discount.DiscountRate : (decimal?)null))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.Any() ? src.Images.First().Url : null))
                .ReverseMap();
            CreateMap<ProductEntity, CategorySliderViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color))
                .ForMember(dest => dest.IconCssClass, opt => opt.MapFrom(src => src.Category.IconCssClass))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.Any() ? src.Images.First().Url : null))
                .ReverseMap();
            CreateMap<ProductEntity, FeaturedProductViewModel>().ReverseMap();

            //CategoryEntity Mapping
            CreateMap<CategoryEntity, CategoryListViewModel>().ReverseMap();

            //BlogEntity Mapping
            CreateMap<BlogEntity, BlogSummaryViewModel>().ReverseMap();
        }
    }
}
