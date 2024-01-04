using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Infrastructure.Configuration;
using Microservices.Catalog.Infrastructure.Data;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Services
{
    public class CatalogSeedService : ICatalogSeedService
    {
        private readonly CatalogMongoDbSettings _catalogMongoDbSettings;

        public CatalogSeedService(IOptions<CatalogMongoDbSettings> catalogMongoDbSettings)
        {
            _catalogMongoDbSettings = catalogMongoDbSettings.Value;
        }
        public void SeedData()
        {
            var client = new MongoClient(_catalogMongoDbSettings.ConnectionString);
            var database = client.GetDatabase(_catalogMongoDbSettings.DatabaseName);

            var brandsCollection = database.GetCollection<ProductBrandEntity>(_catalogMongoDbSettings.BrandsCollection.Name);
            var typesCollection = database.GetCollection<ProductTypeEntity>(_catalogMongoDbSettings.TypesCollection.Name);
            var productsCollection = database.GetCollection<ProductEntity>(_catalogMongoDbSettings.ProductsCollection.Name);

            SeedCollection.SeedData("", brandsCollection);
            SeedCollection.SeedData("", typesCollection);
            SeedCollection.SeedData("", productsCollection);
        }
    }
}
