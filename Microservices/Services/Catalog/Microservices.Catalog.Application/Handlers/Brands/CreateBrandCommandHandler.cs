using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Responses.Brands;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
    {
        private readonly IRepository<ProductBrandEntity, string> _repository;

        public CreateBrandCommandHandler(
            IRepository<ProductBrandEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var createdBrand = await _repository.CreateAsync(request.BrandEntity);

            var brandDto = CatalogMapper.Mapper.Map<BrandDto>(createdBrand);

            return new CreateBrandResponse
            {
                Brand = brandDto
            };
        }
    }
}
