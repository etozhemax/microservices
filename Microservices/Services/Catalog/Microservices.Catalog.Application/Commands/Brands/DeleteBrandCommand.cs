using MediatR;
using Microservices.Catalog.Application.Responses.Brands;

namespace Microservices.Catalog.Application.Commands.Brands
{
    public class DeleteBrandCommand : IRequest<bool>
    {
        public string BrandId { get; set; }
    }
}
