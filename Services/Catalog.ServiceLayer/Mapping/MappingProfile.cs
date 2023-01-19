using AutoMapper;
using Catalog.Data.DTO;
using Catalog.Data.Entity;

namespace Catalog.ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = CreateMap<ProductDTO, Product>().ReverseMap();
            _ = CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
