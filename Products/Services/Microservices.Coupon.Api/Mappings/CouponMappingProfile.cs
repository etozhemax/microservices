using AutoMapper;
using Microservices.Coupon.Api.Data;
using Microservices.Coupon.Api.Dtos;

namespace Microservices.Coupon.Api.Mappings
{
    public class CouponMappingProfile: Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<CouponEntity, CouponDto>().ReverseMap();
        }
    }
}
