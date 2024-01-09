using MediatR;
using Microservices.Catalog.Application.Responses.Products;

namespace Microservices.Catalog.Application.Queries.Products
{
    public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
    {
        public string Id { get; set; }
    }
}
