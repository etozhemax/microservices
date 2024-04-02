using MediatR;
using Microservices.Catalog.Application.Responses.Products;
using Microservices.Catalog.Core.Entities;

namespace Microservices.Catalog.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public ProductEntity Product { get; set; }
    }
}
