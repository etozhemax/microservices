using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
    {
        private readonly IRepository<ProductBrandEntity, string> _repository;

        public GetByIdBrandQueryHandler(IRepository<ProductBrandEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            var brandsEntity = await _repository.GetByIdAsync(request.Id);

            var brandsDto = CatalogMapper.Mapper.Map<BrandDto>(brandsEntity);

            return new GetByIdBrandResponse
            {
                Brand = brandsDto
            };
        }
    }
}
