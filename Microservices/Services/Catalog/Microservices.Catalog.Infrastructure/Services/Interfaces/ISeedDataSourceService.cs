using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Services.Interfaces
{
    public interface ISeedDataSourceService
    {
        Task SeedData<TEntity>(string sourceFilePath, IMongoCollection<TEntity> collection);
    }
}
