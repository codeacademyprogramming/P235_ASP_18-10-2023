using AutoMapper;
using P235FirstApi.DTOs.CategoriesDTOs;
using P235FirstApi.Entities;

namespace P235FirstApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryPostDTO, Category>()
                .ForMember(des=>des.Name,opt=>opt.MapFrom(src=>src.Ad.Trim()))
                .ForMember(des=>des.IsMain, opt=>opt.MapFrom(src=>src.Esasdir))
                .ForMember(des=>des.ParentId, opt=>opt.MapFrom(src=>src.UstCategoryId))
                .ForMember(des=>des.Image, opt=>opt.MapFrom(src=>src.file != null ? "sekilmap.jpg":"test.jpg"));

            CreateMap<Category, CategoryListDTO>();

            CreateMap<Category, CategoryGetDto>();

            CreateMap<Category, CategoryChildDto>();
        }
    }
}
