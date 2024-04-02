using Microservices.Products.Frontend.Features.Auth.Enums;
using Microservices.Products.Frontend.Features.Coupon.Dtos;
using Microservices.Products.Frontend.Features.Coupon.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Products.Frontend.Features.Coupon.Controllers
{
    [Authorize(Roles = RoleType.Admin)]
	public class CouponController : Controller
    {
		private readonly ICouponService _couponService;

		public CouponController(ICouponService couponService)
        {
			_couponService = couponService;
		}

        public async Task<IActionResult> Index()
        {
            var coupons = await _couponService.GetCoupons();

            if (coupons == null || !coupons.Success)
            {
                TempData["Toastr_Error"] = coupons.Message;
            }

            return View(coupons);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CouponDto couponDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var responseDto = await _couponService.AddCoupon(couponDto);

			if (!responseDto.Success)
			{
                TempData["Toastr_Error"] = responseDto.Message;

                return View();
			}

            TempData["Toastr_Success"] = "Success!";

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var couponDto = await _couponService.GetCouponById(id);

            if (couponDto == null || couponDto.Data == null)
            {
                return NotFound();
            }

            return View(couponDto.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDto couponDto)
        {
            var responseDto = await _couponService.DeleteCoupon(couponDto.CouponId);

            if (responseDto == null || !responseDto.Success)
            {
                TempData["Toastr_Error"] = responseDto.Message;

                return View();
            }

            TempData["Toastr_Success"] = "Success!";

            return RedirectToAction("Index");
        }
    }
}
