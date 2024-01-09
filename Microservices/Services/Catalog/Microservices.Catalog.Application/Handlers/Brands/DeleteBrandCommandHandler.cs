using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteProductResponse>
    {
        public Task<DeleteProductResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
