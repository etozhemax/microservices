using Microservices.Products.Api.Data.Context;
using Microservices.Products.Api.Mappings;
using Microservices.Products.Api.Services;
using Microservices.Products.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microservices.Products.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddConfiguredAutoMapper(this IServiceCollection services)
        {
            var couponMapper = ProductMappings.CreateCouponMapperConfiguration();

            services.AddSingleton(couponMapper);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddConfiguredDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddConfiguredProductServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }

        public static void AddConfiguredAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration.GetValue<string>("JwtTokenOptions:Secret");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secret);
            var issuer = configuration.GetValue<string>("JwtTokenOptions:Issuer");
            var audience = configuration.GetValue<string>("JwtTokenOptions:Audience");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyInBytes),
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuer = true,
                    ValidIssuer = issuer
                };
            });

            services.AddAuthorization();
        }
    }
}
