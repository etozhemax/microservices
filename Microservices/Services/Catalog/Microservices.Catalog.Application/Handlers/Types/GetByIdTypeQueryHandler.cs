using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Queries.Types;
using Microservices.Catalog.Application.Responses.Types;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Types
{
    public class GetByIdTypeQueryHandler : IRequestHandler<GetByIdTypeQuery, GetByIdTypeResponse>
    {
        private readonly IRepository<ProductTypeEntity, string> _repository;

        public GetByIdTypeQueryHandler(IRepository<ProductTypeEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdTypeResponse> Handle(GetByIdTypeQuery request, CancellationToken cancellationToken)
        {
            var typeEntity = await _repository.GetByIdAsync(request.Id);

            var typeDto = CatalogMapper.Mapper.Map<TypeDto>(typeEntity);

            return new GetByIdTypeResponse
            {
                Type = typeDto
            };
        }
    }
}
