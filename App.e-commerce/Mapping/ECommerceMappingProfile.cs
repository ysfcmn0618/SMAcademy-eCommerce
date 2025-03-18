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
            CreateMap<ProductEntity, ProductViewComponentModel>()
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src =>
                src.Images.Any() ? src.Images.First().Url : "theme/img/categories/cat-1.jpg")) // Eğer resim yoksa varsayılan bir görsel kullanın.
                .ReverseMap();
            CreateMap<ProductEntity, ProductListingViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount != null ? src.Discount.DiscountRate : (decimal?)null))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.Any() ? src.Images.First().Url : null))
                .ReverseMap();
            //CreateMap<ProductEntity, CategorySliderViewModel>().ReverseMap();
            CreateMap<ProductEntity, FeaturedProductViewModel>().ReverseMap();
            CreateMap<ProductEntity, FeaturedProductViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
                     src.Category != null ? src.Category.Name : "Uncategorized")) // Kategori adı eşleme
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src =>
                src.Discount != null ? (byte?)src.Discount.DiscountRate : null)) // İndirim oranı eşleme
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                     src.Images != null && src.Images.Any() ? src.Images.First().Url : "default-image.jpg")); // İlk resim eşleme

            //CategoryEntity Mapping
            CreateMap<CategoryEntity, CategoryListViewModel>().ReverseMap();

            //BlogEntity Mapping
            CreateMap<BlogEntity, BlogSummaryViewModel>()
                .ForMember(x=>x.CommentCount,opt=>opt.MapFrom(src=>src.Comments.Count))
                .ForMember(x=>x.SummaryContent,opt=>opt.MapFrom(src=>src.Content.Substring(0,100)))
                .ReverseMap();
        }
    }
}
