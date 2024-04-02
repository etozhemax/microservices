using Microservices.Coupon.Api.Dtos;

namespace Microservices.Coupon.Api.Services.Interfaces
{
    public interface ICouponService
    {
        public Task<IReadOnlyList<CouponDto>> GetCoupons();
        public Task<CouponDto> GetCouponById(int id);
        public Task<CouponDto> GetCouponByCode(string code);
        public Task<CouponDto> AddCoupon(CouponDto couponDto);
        public Task<CouponDto> UpdateCoupon(CouponDto couponDto);
        public Task DeleteCoupon(int id);
    }
}
