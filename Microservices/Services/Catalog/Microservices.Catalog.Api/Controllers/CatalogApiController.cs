using MediatR;
using Microservices.Catalog.Application.Queries.Products;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Catalog.Api.Controllers
{
    public class CatalogApiController : ApiController
    {
        private readonly IMediator _mediator;

        public CatalogApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
