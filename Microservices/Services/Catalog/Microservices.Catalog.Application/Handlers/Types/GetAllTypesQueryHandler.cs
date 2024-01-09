using MediatR;
using Microservices.Catalog.Application.Dtos;
using Microservices.Catalog.Application.Mappings;
using Microservices.Catalog.Application.Queries.Types;
using Microservices.Catalog.Application.Responses.Types;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Types
{
    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, GetAllTypesQueryResponse>
    {
        private readonly IRepository<ProductTypeEntity, string> _repository;

        public GetAllTypesQueryHandler(IRepository<ProductTypeEntity, string> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllTypesQueryResponse> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesEntities = await _repository.GetAllAsync();

            var typesDtos = CatalogMapper.Mapper.Map<IReadOnlyList<TypeDto>>(typesEntities);

            return new GetAllTypesQueryResponse
            {
                Types = typesDtos
            };
        }
    }
}
