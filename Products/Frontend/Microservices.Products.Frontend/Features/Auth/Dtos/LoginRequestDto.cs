using System.ComponentModel.DataAnnotations;

namespace Microservices.Products.Frontend.Features.Auth.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        public string? UserName { get; set; } = default;

        [Required]
        public string? Password { get; set; } = default;
    }
}
