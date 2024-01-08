using Microservices.Catalog.Infrastructure.Services.Interfaces;
using MongoDB.Driver;
using System.Text.Json;

namespace Microservices.Catalog.Infrastructure.Services
{
    public class SeedDataSourceService : ISeedDataSourceService
    {
        public async Task SeedData<TEntity>(string sourceFilePath, IMongoCollection<TEntity> collection)
        {
            var hasData = collection.Find(x => true).Any();

            if (!hasData)
            {
                var rawData = File.ReadAllText(sourceFilePath);

                var deserializedData = JsonSerializer.Deserialize<IEnumerable<TEntity>>(rawData);

                if (deserializedData != null && deserializedData.Count() > 0)
                {
                    await collection.InsertManyAsync(deserializedData);
                }
            }
        }
    }
}
