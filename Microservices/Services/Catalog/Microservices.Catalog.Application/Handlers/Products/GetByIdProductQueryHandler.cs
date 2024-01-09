using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Queries.Products;
using Microservices.Catalog.Application.Responses.Products;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Products
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IRepository<ProductEntity, string> _repository;

        public GetByIdProductQueryHandler(IRepository<ProductEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _repository.GetByIdAsync(request.Id);

            var productDto = CatalogMapper.Mapper.Map<ProductDto>(productEntity);

            return new GetByIdProductResponse
            {
                Product = productDto
            };
        }
    }
}
