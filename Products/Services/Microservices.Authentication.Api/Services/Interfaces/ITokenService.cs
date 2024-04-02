using Microservices.Authentication.Api.Data;

namespace Microservices.Authentication.Api.Services.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(AppUser user, IReadOnlyList<string> roles);
    }
}
