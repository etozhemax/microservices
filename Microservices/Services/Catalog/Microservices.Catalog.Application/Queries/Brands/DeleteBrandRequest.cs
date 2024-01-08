using MediatR;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Requests.Brands
{
    public class DeleteBrandRequest : IRequest<DeleteBrandResponse>
    {
    }
}
