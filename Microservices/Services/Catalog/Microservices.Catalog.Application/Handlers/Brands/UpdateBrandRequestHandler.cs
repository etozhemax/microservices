using MediatR;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class UpdateBrandRequestHandler : IRequestHandler<UpdateBrandRequest, UpdateBrandResponse>
    {
        public Task<UpdateBrandResponse> Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
