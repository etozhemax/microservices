using AutoMapper;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Core.Entities;

namespace Microservices.Catalog.Application.Mappings
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<ProductBrandEntity, BrandDto>().ReverseMap();
        }
    }
}
