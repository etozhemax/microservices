using MediatR;
using Microservices.Catalog.Application.Responses.Brands;
using Microservices.Catalog.Core.Entities;

namespace Microservices.Catalog.Application.Commands.Brands
{
    public class CreateBrandCommand : IRequest<CreateBrandResponse>
    {
        public ProductBrandEntity BrandEntity { get; set; }
    }
}
