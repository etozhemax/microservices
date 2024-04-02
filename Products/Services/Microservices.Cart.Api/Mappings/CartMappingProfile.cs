using AutoMapper;
using Microservices.Cart.Api.Data;
using Microservices.Cart.Api.Dtos;

namespace Microservices.Cart.Api.Mappings
{
    public class CartMappingProfile: Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartEntity, ProductDto>().ReverseMap();
        }
    }
}
