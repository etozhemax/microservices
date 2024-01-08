using MediatR;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    internal class GetByIdBrandRequestHandler : IRequestHandler<GetByIdBrandRequest, GetByIdBrandResponse>
    {
        public Task<GetByIdBrandResponse> Handle(GetByIdBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
