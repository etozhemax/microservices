using Microservices.Products.Frontend.Configuration;
using Microservices.Products.Frontend.Features.Auth.Services;
using Microservices.Products.Frontend.Features.Auth.Services.Interfaces;
using Microservices.Products.Frontend.Features.Coupon.Services;
using Microservices.Products.Frontend.Features.Coupon.Services.Interfaces;
using Microservices.Products.Frontend.Features.Products.Services;
using Microservices.Products.Frontend.Features.Products.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Microservices.Products.Frontend.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCouponServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CouponApiOptions>(configuration.GetSection("Urls:CouponApi"));

			services.AddHttpClient<ICouponService, CouponService>();

            services.AddScoped<ICouponService, CouponService>();
        }

        public static void AddProductServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProductApiOptions>(configuration.GetSection("Urls:ProductsApi"));

            services.AddHttpClient<IProductService, ProductService>();

            services.AddScoped<IProductService, ProductService>();
        }

        public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthApiOptions>(configuration.GetSection("Urls:AuthApi"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });

            services.AddHttpClient<IAuthService, AuthService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICookieTokenProvider, CookieTokenProvider>();
        }
    }
}
