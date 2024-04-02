using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Coupon.Dtos;

namespace Microservices.Products.Frontend.Features.Coupon.Services.Interfaces
{
    public interface ICouponService
    {
        public Task<ResponseDto<IReadOnlyList<CouponDto>>?> GetCoupons();
        public Task<ResponseDto<CouponDto>?> GetCouponById(int id);
        public Task<ResponseDto<CouponDto>?> GetCouponByCode(string code);
        public Task<ResponseDto<CouponDto>?> AddCoupon(CouponDto couponDto);
        public Task<ResponseDto<CouponDto>?> UpdateCoupon(CouponDto couponDto);
        public Task<ResponseDto<CouponDto>?> DeleteCoupon(int id);
    }
}
