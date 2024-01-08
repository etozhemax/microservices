using Microservices.Catalog.Application.Dtos;

namespace Microservices.Catalog.Application.Responses.Brands
{
    public class GetAllBrandsQueryResponse
    {
        public IReadOnlyList<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }
}
