using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateProductResponse>
    {
        public Task<UpdateProductResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
