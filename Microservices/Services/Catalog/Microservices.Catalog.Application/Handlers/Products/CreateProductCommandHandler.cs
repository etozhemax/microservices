using MediatR;
using Microservices.Catalog.Application.Commands.Products;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Responses.Products;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IRepository<ProductEntity, string> _repository;

        public CreateProductCommandHandler(
            IRepository<ProductEntity, string> repository
            )
        {
            _repository = repository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createdProduct = await _repository.CreateAsync(request.Product);

            var productDto = CatalogMapper.Mapper.Map<ProductDto>(createdProduct);

            return new CreateProductResponse { Product = productDto };
        }
    }
}
