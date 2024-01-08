using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using MongoDB.Driver;

namespace Microservices.Catalog.Infrastructure.Repositories
{
    public class TypesRepository : IRepository<ProductTypeEntity, string>
    {
        private readonly ICatalogContextService _catalogContextService;

        public TypesRepository(
            ICatalogContextService catalogContextService
            )
        {
            _catalogContextService = catalogContextService;
        }

        public async Task<ProductTypeEntity> CreateAsync(ProductTypeEntity entity)
        {
            await _catalogContextService.Types.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(ProductTypeEntity entity)
        {
            var filterDefinitionBulder = Builders<ProductTypeEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, entity.Id);

            var updateResult = await _catalogContextService.Types.ReplaceOneAsync(filterDefinition, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductTypeEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var deletingResult = await _catalogContextService.Types.DeleteOneAsync(filterDefinition);

            return deletingResult.IsAcknowledged && deletingResult.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<ProductTypeEntity>> GetAllAsync()
        {
            var findResult = await _catalogContextService.Types.FindAsync(x => true);
            var entities = await findResult.ToListAsync();

            return entities;
        }

        public async Task<ProductTypeEntity> GetByIdAsync(string id)
        {
            var filterDefinitionBulder = Builders<ProductTypeEntity>.Filter;
            var filterDefinition = filterDefinitionBulder.Eq(x => x.Id, id);

            var findResult = await _catalogContextService.Types.FindAsync(filterDefinition);

            var entity = await findResult.FirstOrDefaultAsync();

            return entity;
        }
    }
}
