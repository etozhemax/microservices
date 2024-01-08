using MediatR;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Requests.Brands
{
    internal class GetByIdBrandRequest : IRequest<GetByIdBrandResponse>
    {
    }
}
