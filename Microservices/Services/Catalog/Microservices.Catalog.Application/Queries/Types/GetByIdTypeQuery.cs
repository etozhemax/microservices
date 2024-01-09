using MediatR;
using Microservices.Catalog.Application.Responses.Types;

namespace Microservices.Catalog.Application.Queries.Types
{
    public class GetByIdTypeQuery : IRequest<GetByIdTypeResponse>
    {
        public string Id { get; set; }
    }
}
