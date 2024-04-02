using Microsoft.AspNetCore.Identity;

namespace Microservices.Authentication.Api.Data
{
    public class AppUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}
