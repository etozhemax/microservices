using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Infrastructure.Configuration;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Services
{
    public class CatalogContextService : ICatalogContextService
    {
        public IMongoCollection<ProductBrandEntity> Brands { get; set; }
        public IMongoCollection<ProductTypeEntity> Types { get; set; }
        public IMongoCollection<ProductEntity> Products { get; set; }


        public CatalogContextService(
            ISeedDataSourceService dataSourceService,
            IOptions<CatalogMongoDbSettings> catalogMongoDbSettings)
        {

            InitializeContext(dataSourceService, catalogMongoDbSettings);
        }

        public void InitializeContext(ISeedDataSourceService dataSourceService, IOptions<CatalogMongoDbSettings> catalogMongoDbSettings)
        {
            var catalogSettings = catalogMongoDbSettings.Value;

            var client = new MongoClient(catalogSettings.ConnectionString);
            var database = client.GetDatabase(catalogSettings.DatabaseName);

            Brands = database.GetCollection<ProductBrandEntity>(catalogSettings.BrandsCollection.Name);
            Types = database.GetCollection<ProductTypeEntity>(catalogSettings.TypesCollection.Name);
            Products = database.GetCollection<ProductEntity>(catalogSettings.ProductsCollection.Name);

            dataSourceService.SeedData(Path.Combine("Data", "Collections", "brands.json"), Brands);
            dataSourceService.SeedData(Path.Combine("Data", "Collections", "types.json"), Types);
            dataSourceService.SeedData(Path.Combine("Data", "Collections", "pproducts.json"), Products);
        }
    }
}
