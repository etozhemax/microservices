using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ErrorPageController : Controller
    {
        private readonly ILogger<ErrorPageController> _logger;

        public ErrorPageController(ILogger<ErrorPageController> logger)
        {
            _logger = logger;
        }

        [Route("{id}.xml")]
        public IActionResult ErrorPage()
        {
            return Content("test");
        }
    }
}
