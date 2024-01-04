using MongoDB.Driver;
using System.Text.Json;

namespace Microservices.Catalog.Infrastructure.Data
{
    public static class SeedCollection
    {
        public static async void SeedData<TEntity>(string filePath, IMongoCollection<TEntity> collection)
        {
            var hasData = collection.Find(x => true).Any();

            if (!hasData)
            {
                var rawData = File.ReadAllText(filePath);
                var deserializedData = JsonSerializer.Deserialize<IEnumerable<TEntity>>(rawData);

                if (deserializedData != null && deserializedData.Count() > 0)
                {
                    await collection.InsertManyAsync(deserializedData);
                }
            }
        }
    }
}
