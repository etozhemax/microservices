using Microservices.Authentication.Api.Data;
using Microservices.Authentication.Api.Data.Context;
using Microservices.Authentication.Api.Models;
using Microservices.Authentication.Api.Services;
using Microservices.Authentication.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Authentication.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtTokenOptions>(configuration.GetSection("JwtTokenOptions"));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, JwtTokenService>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
