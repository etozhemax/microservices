using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;
using Microservices.Catalog.Infrastructure.Repositories;
using Microservices.Catalog.Infrastructure.Services;
using Microservices.Catalog.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Catalog.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ISeedDataSourceService, SeedDataSourceService>();
            services.AddSingleton<ICatalogContextService, CatalogContextService>();

            services.AddScoped<IRepository<ProductBrandEntity, string>, BrandsRepository>();
            services.AddScoped<IRepository<ProductEntity, string>, ProductRepository>();
            services.AddScoped<IRepository<ProductTypeEntity, string>, TypesRepository>();

            return services;
        }
    }
}
