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

            return services;
        }
    }
}
