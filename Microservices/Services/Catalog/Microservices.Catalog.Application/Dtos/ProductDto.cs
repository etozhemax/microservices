using Microservices.Catalog.Core.Entities;

namespace Microservices.Catalog.Application.Dtos
{
    public class ProductDto
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public string? ImageFile { get; set; }

        public ProductBrandEntity? Brands { get; set; }

        public ProductTypeEntity? Types { get; set; }

        public decimal? Price { get; set; }
    }
}
