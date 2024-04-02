using Microservices.Products.Frontend.Features.Products.Services.Interfaces;
using Microservices.Products.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Microservices.Products.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetProducts();

            if (response == null || !response.Success) 
            {
                return NotFound();
            }

            return View(response.Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
