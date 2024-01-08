using MediatR;
using Microservices.Catalog.Application.Requests.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class DeleteBrandRequestHandler : IRequestHandler<DeleteBrandRequest, DeleteBrandResponse>
    {
        public Task<DeleteBrandResponse> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
