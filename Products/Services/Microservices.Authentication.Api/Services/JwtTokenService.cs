using Microservices.Authentication.Api.Data;
using Microservices.Authentication.Api.Models;
using Microservices.Authentication.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservices.Authentication.Api.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtTokenOptions _tokenOptions;

        public JwtTokenService(IOptions<JwtTokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public string GetToken(AppUser user, IReadOnlyList<string> roles)
        {
            var key = Encoding.ASCII.GetBytes(_tokenOptions.Secret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Name, user.Name)
            };

            if (!roles.IsNullOrEmpty())
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var jwtTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _tokenOptions.Audience,
                Issuer = _tokenOptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(jwtTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
