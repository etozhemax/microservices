using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Microservices.Catalog.Core.Entities
{
    public class ProductEntity : BaseEntity
    {
        [BsonElement("Name")]
        public required string Name { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public string? ImageFile { get; set; }

        public ProductBrandEntity? Brands { get; set; }

        public ProductTypeEntity? Types { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? Price { get; set; }
    }
}
