using App.Admin.Models.CategoryViewModels;
using App.Data.Entities;
using AutoMapper;


namespace App.Admin.Mapping
{
    public class AdminMappingProfile:Profile
    {
        public AdminMappingProfile()
        {
           CreateMap<CategoryModel, CategoryEntity>().ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ReverseMap();
            //CreateMap<CategoryEntity, CategoryEditModel>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<IEnumerable<CategoryEntity>, IEnumerable<CategoryListModel>>().ReverseMap();
        }
    }
}
