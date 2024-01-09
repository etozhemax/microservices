using Microservices.Catalog.Application.Dtos;

namespace Microservices.Catalog.Application.Responses.Types
{
    public class GetAllTypesQueryResponse
    {
        public IReadOnlyList<TypeDto> Types { get; set; } = new List<TypeDto>();
    }
}
