using AutoMapper;
using Microservices.Products.Api.Data;
using Microservices.Products.Api.Dtos;

namespace Microservices.Products.Api.Mappings
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
