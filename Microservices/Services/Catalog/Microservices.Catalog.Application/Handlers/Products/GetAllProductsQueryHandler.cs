using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Queries.Products;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;
using Microservices.Catalog.Application.Responses.Products;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductQueryResponse>
    {
        private readonly IRepository<ProductEntity, string> _repository;

        public GetAllProductsQueryHandler(IRepository<ProductEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsEntities = await _repository.GetAllAsync();

            var productsDtos = CatalogMapper.Mapper.Map<IReadOnlyList<ProductDto>>(productsEntities);

            return new GetAllProductQueryResponse
            {
                Products = productsDtos
            };
        }
    }
}
