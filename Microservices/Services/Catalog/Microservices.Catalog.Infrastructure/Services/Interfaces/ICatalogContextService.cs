using Microservices.Catalog.Core.Entities;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Services.Interfaces
{
    public interface ICatalogContextService
    {
        public IMongoCollection<ProductBrandEntity> Brands { get; set; }
        public IMongoCollection<ProductTypeEntity> Types { get; set; }
        public IMongoCollection<ProductEntity> Products { get; set; }
    }
}
