using AutoMapper;
using Microservices.Coupon.Api.Data;
using Microservices.Coupon.Api.Data.Context;
using Microservices.Coupon.Api.Dtos;
using Microservices.Coupon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Coupon.Api.Services
{
    public class CouponService : ICouponService
    {
        private readonly CouponDbContext _dbContext;
        private readonly IMapper _mapper;

        public CouponService(
            CouponDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CouponDto> AddCoupon(CouponDto couponDto)
        {
            var couponEntity = _mapper.Map<CouponEntity>(couponDto);

            await _dbContext.Coupons.AddAsync(couponEntity);

            await _dbContext.SaveChangesAsync();

            return couponDto;
        }

        public async Task DeleteCoupon(int id)
        {
            var couponEntity = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);

            if (couponEntity != null)
            {
                _dbContext.Coupons.Remove(couponEntity);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CouponDto> GetCouponByCode(string code)
        {
            var couponEntity = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.CouponCode == code);

            var couponDto = _mapper.Map<CouponDto>(couponEntity);

            return couponDto;
        }

        public async Task<CouponDto> GetCouponById(int id)
        {
            var couponEntity = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);

            var couponDto = _mapper.Map<CouponDto>(couponEntity);

            return couponDto;
        }

        public async Task<IReadOnlyList<CouponDto>> GetCoupons()
        {
            var couponEntities = await _dbContext.Coupons.ToListAsync();

            var couponDtos = _mapper.Map<IReadOnlyList<CouponDto>>(couponEntities);

            return couponDtos;
        }

        public async Task<CouponDto> UpdateCoupon(CouponDto couponDto)
        {
            var couponEntity = _mapper.Map<CouponEntity>(couponDto);

            _dbContext.Coupons.Update(couponEntity);

            await _dbContext.SaveChangesAsync();

            return couponDto;
        }
    }
}
