namespace Microservices.Products.Frontend.Features.Auth.Services.Interfaces
{
    public interface ICookieTokenProvider
    {
        bool SetToken(string? token);
        string? GetToken();
        void ClearToken();
    }
}
