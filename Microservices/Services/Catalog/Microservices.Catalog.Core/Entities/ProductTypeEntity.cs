using MongoDB.Bson.Serialization.Attributes;

namespace Microservices.Catalog.Core.Entities
{
    public class ProductTypeEntity : BaseEntity
    {
        [BsonElement("Name")]
        public required string Name { get; set; }
    }
}
