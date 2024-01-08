using AutoMapper;

namespace Microservices.Catalog.Application.Mappings
{
    public static class CatalogMapper
    {
        private static Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var mapperConfiguration = new MapperConfiguration((configuration) =>
            {
                configuration.ShouldMapProperty = property => property.GetMethod.IsPublic || property.GetMethod.IsAssembly;
                configuration.AddProfile<CatalogMappingProfile>();
            });

            return mapperConfiguration.CreateMapper();
        });

        public static IMapper Mapper => _mapper.Value;
    }
}
