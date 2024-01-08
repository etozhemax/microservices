using MediatR;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class CreateBrandRequestHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
    {
        public Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
