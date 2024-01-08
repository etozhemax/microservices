using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class GetAllBrandsRequestHandler : IRequestHandler<GetAllBrandsQuery, GetAllBrandsQueryResponse>
    {
        private readonly IRepository<ProductBrandEntity, string> _repository;

        public GetAllBrandsRequestHandler(IRepository<ProductBrandEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllBrandsQueryResponse> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandsEntities = await _repository.GetAllAsync();
            
            var brandsDtos = CatalogMapper.Mapper.Map<IReadOnlyList<BrandDto>>(brandsEntities);

            return new GetAllBrandsQueryResponse
            {
                Brands = brandsDtos
            };
        }
    }
}
