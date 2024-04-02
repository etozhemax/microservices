using MediatR;
using Microservices.Catalog.Core.Entities;

namespace Microservices.Catalog.Application.Commands.Brands
{
    public class UpdateBrandCommand : IRequest<bool>
    {
        public ProductBrandEntity Brand { get; set; }
    }
}
