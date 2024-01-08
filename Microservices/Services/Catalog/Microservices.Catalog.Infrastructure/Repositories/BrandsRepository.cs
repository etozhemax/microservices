using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Repositories
{
    public class BrandsRepository : IRepository<ProductBrandEntity, string>
    {
        private readonly ICatalogContextService _catalogContextService;

        public BrandsRepository(
            ICatalogContextService catalogContextService
            )
        {
            _catalogContextService = catalogContextService;
        }

        public async Task<ProductBrandEntity> CreateAsync(ProductBrandEntity entity)
        {
            await _catalogContextService.Brands.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(ProductBrandEntity entity)
        {
            var filterDefinitionBulder = Builders<ProductBrandEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, entity.Id);

            var updateResult = await _catalogContextService.Brands.ReplaceOneAsync(filterDefinition, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductBrandEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var deletingResult = await _catalogContextService.Brands.DeleteOneAsync(filterDefinition);

            return deletingResult.IsAcknowledged && deletingResult.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<ProductBrandEntity>> GetAllAsync()
        {
            var findResult = await _catalogContextService.Brands.FindAsync(x => true);
            var entities = await findResult.ToListAsync();

            return entities;
        }

        public async Task<ProductBrandEntity> GetByIdAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductBrandEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var findResult = await _catalogContextService.Brands.FindAsync(filterDefinition);

            var entity = await findResult.FirstOrDefaultAsync();

            return entity;
        }
    }
}
