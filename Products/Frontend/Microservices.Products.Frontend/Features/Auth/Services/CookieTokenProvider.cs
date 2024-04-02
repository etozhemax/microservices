using Microservices.Products.Frontend.Features.Auth.Services.Interfaces;

namespace Microservices.Products.Frontend.Features.Auth.Services
{
    public class CookieTokenProvider : ICookieTokenProvider
    {
        private const string JWT_TOKEN_KEY = "JwtToken";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ClearToken()
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(JWT_TOKEN_KEY);
        }

        public string? GetToken()
        {
            var token = string.Empty;

            _httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(JWT_TOKEN_KEY, out token);

            return token;
        }

        public bool SetToken(string? token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var context = _httpContextAccessor.HttpContext;

                if (context != null)
                {
                    context.Response.Cookies.Append(JWT_TOKEN_KEY, token);

                    return true;
                }
            }

            return false;
        }
    }
}
