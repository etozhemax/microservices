using AutoMapper;

namespace Microservices.Coupon.Api.Mappings
{
    public static class CouponMappings
    {
        public static MapperConfiguration CreateCouponMapperConfiguration()
        {
            return new MapperConfiguration(exp => exp.AddProfile<CouponMappingProfile>());
        }
    }
}
