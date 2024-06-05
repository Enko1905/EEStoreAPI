using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace StoreApi.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForUpdate, Products>();
            CreateMap<Products,ProductDto>();
            CreateMap<ProductDtoForInsertion, Products>();
        }
    }
}
