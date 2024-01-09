using MediatR;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Commands.Brands
{
    public class UpdateBrandCommand : IRequest<UpdateProductResponse>
    {
    }
}
