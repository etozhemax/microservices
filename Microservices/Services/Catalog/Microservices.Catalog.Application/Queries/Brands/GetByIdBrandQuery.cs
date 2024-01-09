using MediatR;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Requests.Brands
{
    public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
    {
        public string Id { get; set; }
    }
}
