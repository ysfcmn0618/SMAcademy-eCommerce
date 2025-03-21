using App.Data.Entities;
using App.eCommerce.Models.ViewModels.AuthViewModels;
using App.eCommerce.Models.ViewModels.BlogViewModels;
using App.eCommerce.Models.ViewModels.CartItemViewModel;
using App.eCommerce.Models.ViewModels.CategoryViewModels;
using App.eCommerce.Models.ViewModels.HomeControllerViewModels;
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
            CreateMap<RegisterUserViewModel, UserEntity>()
                .ConstructUsing(src => new UserEntity { RoleId = 3 })//varsayılan değer olarak 3 ata 
                 .AfterMap((src, dest) =>//değer boş ise gene 3 ata
                 {
                     if (dest.RoleId == 0) // veya dest.RoleId == null (eğer nullable ise)
                     {
                         dest.RoleId = 3;
                     }
                 })
                .ReverseMap();
            CreateMap<ForgotPasswordViewModel, UserEntity>();
            CreateMap<LoginViewModel, UserEntity>();
            CreateMap<RegisterUserViewModel, UserEntity>().ReverseMap();
            CreateMap<RenevPasswordViewModel, UserEntity>();
            #region Product Mapping
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
            CreateMap<ProductEntity, HomeProductDetailViewModel>()
                .ForMember(x => x.DiscountRate, opt => opt.MapFrom(src => src.Discount.DiscountRate))
                .ForMember(x => x.SellerName, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(x => x.ImageUrls, opt => opt.MapFrom(src => src.Images.ToArray()))
                .ForMember(x => x.Reviews, opt => opt.MapFrom(src => src.Comments != null ? src.Comments.ToArray() : new ProductCommentEntity[0])).ReverseMap();
            CreateMap<ProductCommentEntity, ProductReviewViewModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}")).ReverseMap();


            #endregion

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
                .ForMember(x => x.CommentCount, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(x => x.SummaryContent, opt => opt.MapFrom(src => src.Content.Substring(0, 100)))
                .ReverseMap();


            //BlogCategory Mapping
            CreateMap<BlogCategoryEntity, BlogCategorySidebarViewModel>()
                .ForMember(x => x.ArticleCount, opt => opt.MapFrom(src => src.BlogRelations.Count))
                .ReverseMap();

            //CartItemEntity Mappinf
            CreateMap<CartItemEntity, CartItemViewModel>()
                .ForMember(x => x.ProductImage, opt => opt.MapFrom(src => src.Product.Images.Count != 0 ? src.Product.Images.First().Url : null))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ReverseMap();

            //ContactformEntity Mapping
            CreateMap<ContactFormEntity, NewContactFormMessageViewModel>().ReverseMap();
        }
    }
}
