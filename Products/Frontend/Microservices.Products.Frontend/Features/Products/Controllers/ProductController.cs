using Microservices.Products.Frontend.Features.Auth.Enums;
using Microservices.Products.Frontend.Features.Products.Dtos;
using Microservices.Products.Frontend.Features.Products.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Products.Frontend.Features.Products.Controllers
{
    [Authorize(Roles = RoleType.Admin)]
    public class ProductController : Controller
    {
		private readonly IProductService _productsService;

		public ProductController(IProductService productsService)
        {
			_productsService = productsService;
		}

        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetProducts();

            if (products == null || !products.Success)
            {
                TempData["Toastr_Error"] = products.Message;
            }

            return View(products);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductDto productDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var responseDto = await _productsService.AddProduct(productDto);

			if (!responseDto.Success)
			{
                TempData["Toastr_Error"] = responseDto.Message;

                return View();
			}

            TempData["Toastr_Success"] = "Success!";

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productsService.GetProductById(id);

            if (product == null || !product.Success)
            {
                return NotFound();
            }

            return View(product.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var responseDto = await _productsService.UpdateProduct(productDto);

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
            var productDto = await _productsService.GetProductById(id);

            if (productDto == null || productDto.Data == null)
            {
                return NotFound();
            }

            return View(productDto.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDto couponDto)
        {
            var responseDto = await _productsService.DeleteProduct(couponDto.ProductId);

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
