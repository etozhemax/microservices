using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateProductResponse>
    {
        public Task<CreateProductResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
