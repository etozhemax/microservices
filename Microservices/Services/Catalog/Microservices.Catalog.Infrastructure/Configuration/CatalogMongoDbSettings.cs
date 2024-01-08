namespace Microservices.Catalog.Infrastructure.Configuration
{
    public class CatalogMongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public CatalogCollectionSettings BrandsCollection { get; set; } = default!;
        public CatalogCollectionSettings TypesCollection { get; set; } = default!;
        public CatalogCollectionSettings ProductsCollection { get; set; } = default!;
    }
}
