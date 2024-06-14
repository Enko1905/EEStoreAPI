using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace StoreApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Product Map
            CreateMap<ProductDtoForUpdate, Products>().ReverseMap();
            CreateMap<Products, ProductDto>().ReverseMap();

            CreateMap<ProductDtoForInsertion, Products>();


            //Category Map
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoForInsertion, Category>();

            //MainCategory Map
            CreateMap<MainCategoryDtoUpdate, MainCategory>().ReverseMap();
            CreateMap<MainCategory, MainCategoryDto>();
            CreateMap<MainCategoryDtoInsertion, MainCategory>();

            //SubCategory Map
            CreateMap<SubCategoryDtoForUpdate, SubCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();

            CreateMap<SubCategoryDtoForInsert, SubCategory>();

            //ProductVariant
            CreateMap<ProductVariantDto, ProductVariants>().ReverseMap();

            //ProductAttribute
            CreateMap<ProductAttribute, ProductAttributeDto>().ReverseMap();

            //ProductCustomAttribute
            CreateMap<ProductCustomAttributeDto, ProductCustomAttributes>().ReverseMap();


            //Color
            CreateMap<ColorDto, Color>().ReverseMap();

            //Size
            CreateMap<SizeDto, Size>().ReverseMap();
        }
    }
}
