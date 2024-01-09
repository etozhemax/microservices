using Microservices.Catalog.Application.Dtos;

namespace Microservices.Catalog.Application.Responses.Products
{
    public class GetAllProductQueryResponse
    {
        public IReadOnlyList<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
