using Microservices.Products.Frontend.Configuration;
using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Coupon.Dtos;
using Microservices.Products.Frontend.Features.Coupon.Services.Interfaces;
using Microservices.Products.Frontend.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Microservices.Products.Frontend.Features.Coupon.Services
{
    public class CouponService : ICouponService
    {
        private readonly IApiService _apiService;
        private readonly CouponApiOptions _options;

        public CouponService(IApiService apiService, IOptions<CouponApiOptions> options)
        {
            _apiService = apiService;
            _options = options.Value;
        }

        public async Task<ResponseDto<CouponDto>?> AddCoupon(CouponDto couponDto)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl,
                Type = Utilities.Enums.HttpMethodType.Post,
                Data = couponDto
            };

            var response = await _apiService.SendAsync<CouponDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<CouponDto>?> DeleteCoupon(int id)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + id,
                Type = Utilities.Enums.HttpMethodType.Delete,
            };

            var response = await _apiService.SendAsync<CouponDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<CouponDto>?> GetCouponByCode(string code)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + code,
                Type = Utilities.Enums.HttpMethodType.Get
            };

            var response = await _apiService.SendAsync<CouponDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<CouponDto>?> GetCouponById(int id)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + id,
                Type = Utilities.Enums.HttpMethodType.Get,
            };

            var response = await _apiService.SendAsync<CouponDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<IReadOnlyList<CouponDto>>?> GetCoupons()
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl,
                Type = Utilities.Enums.HttpMethodType.Get
            };

            var response = await _apiService.SendAsync<IReadOnlyList<CouponDto>>(request);

            return response ?? null;
        }

        public Task<ResponseDto<CouponDto>?> UpdateCoupon(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
