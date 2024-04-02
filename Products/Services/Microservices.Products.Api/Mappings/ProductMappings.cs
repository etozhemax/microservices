using AutoMapper;

namespace Microservices.Products.Api.Mappings
{
    public static class ProductMappings
    {
        public static MapperConfiguration CreateCouponMapperConfiguration()
        {
            return new MapperConfiguration(exp => exp.AddProfile<ProductMappingProfile>());
        }
    }
}
