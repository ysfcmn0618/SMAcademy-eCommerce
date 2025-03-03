using App.Data.Entities;
using App.eCommerce.Models.ViewModels.AuthViewModels;
using AutoMapper;

namespace App.eCommerce.Mapping
{
    public class ECommerceMappingProfile:Profile
    {
        public ECommerceMappingProfile()
        {
           CreateMap<RegisterUserModel, UserEntity>().ReverseMap();

        }
    }
}
