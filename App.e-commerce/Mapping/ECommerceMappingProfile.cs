using App.Data.Entities;
using App.eCommerce.Models.ViewModels.AuthViewModels;
using App.eCommerce.Models.ViewModels.HomeViewModels;
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
        }
    }
}
