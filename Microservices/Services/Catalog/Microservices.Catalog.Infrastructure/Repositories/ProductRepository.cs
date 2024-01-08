using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IRepository<ProductEntity, string>
    {
        private readonly ICatalogContextService _catalogContextService;

        public ProductRepository(
            ICatalogContextService catalogContextService
            )
        {
            _catalogContextService = catalogContextService;
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity entity)
        {
            await _catalogContextService.Products.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(ProductEntity entity)
        {
            var filterDefinitionBulder = Builders<ProductEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, entity.Id);

            var updateResult = await _catalogContextService.Products.ReplaceOneAsync(filterDefinition, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var deletingResult = await _catalogContextService.Products.DeleteOneAsync(filterDefinition);

            return deletingResult.IsAcknowledged && deletingResult.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<ProductEntity>> GetAllAsync()
        {
            var findResult = await _catalogContextService.Products.FindAsync(x => true);
            var entities = await findResult.ToListAsync();

            return entities;
        }

        public async Task<ProductEntity> GetByIdAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var findResult = await _catalogContextService.Products.FindAsync(filterDefinition);

            var entity = await findResult.FirstOrDefaultAsync();

            return entity;
        }
    }
}
