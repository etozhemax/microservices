using Microservices.Coupon.Api.Dtos;
using Microservices.Coupon.Api.Helpers;
using Microservices.Coupon.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Coupon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CouponController: ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<ExecutionResult<IReadOnlyList<CouponDto>>> Get()
        {
            ExecutionResult<IReadOnlyList<CouponDto>> result;

            try
            {
                var couponDtos = await _couponService.GetCoupons();

                result = ExecutionResultHelper.CreateSuccessfulResult(couponDtos);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<IReadOnlyList<CouponDto>>(ex.Message);
            }

            return result;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ExecutionResult<CouponDto>> Get(int id)
        {
            ExecutionResult<CouponDto> result;

            try
            {
                var couponDto = await _couponService.GetCouponById(id);

                result = ExecutionResultHelper.CreateSuccessfulResult(couponDto);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<CouponDto>(ex.Message);
            }

            return result;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ExecutionResult<CouponDto>> GetByCode(string code)
        {
            ExecutionResult<CouponDto> result;

            try
            {
                var couponDto = await _couponService.GetCouponByCode(code);

                result = ExecutionResultHelper.CreateSuccessfulResult(couponDto);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<CouponDto>(ex.Message);
            }

            return result;
        }

        [HttpPost]
        public async Task<ExecutionResult<CouponDto>> Add([FromBody] CouponDto couponDto)
        {
            ExecutionResult<CouponDto> result;

            try
            {
                var couponDtoResult = await _couponService.AddCoupon(couponDto);

                result = ExecutionResultHelper.CreateSuccessfulResult(couponDtoResult);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<CouponDto>(ex.Message);
            }

            return result;
        }

        [HttpPut]
        public async Task<ExecutionResult<CouponDto>> Update([FromBody] CouponDto couponDto)
        {
            ExecutionResult<CouponDto> result;

            try
            {
                var couponDtoResult = await _couponService.UpdateCoupon(couponDto);

                result = ExecutionResultHelper.CreateSuccessfulResult(couponDtoResult);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<CouponDto>(ex.Message);
            }

            return result;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ExecutionResult<CouponDto>> Delete(int id)
        {
            ExecutionResult<CouponDto> result;

            try
            {
                await _couponService.DeleteCoupon(id);

                result = ExecutionResultHelper.CreateSuccessfulResult<CouponDto>(null);
            }
            catch (Exception ex)
            {
                result = ExecutionResultHelper.CreateErrorResult<CouponDto>(ex.Message);
            }

            return result;
        }
    }
}
