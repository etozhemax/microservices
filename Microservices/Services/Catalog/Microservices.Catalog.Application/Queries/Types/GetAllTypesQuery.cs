using MediatR;
using Microservices.Catalog.Application.Responses.Types;

namespace Microservices.Catalog.Application.Queries.Types
{
    public class GetAllTypesQuery : IRequest<GetAllTypesQueryResponse>
    {
    }
}
