using AutoMapper;

namespace Microservices.Cart.Api.Mappings
{
    public static class CartMappings
    {
        public static MapperConfiguration CreateCouponMapperConfiguration()
        {
            return new MapperConfiguration(exp => exp.AddProfile<CartMappingProfile>());
        }
    }
}
