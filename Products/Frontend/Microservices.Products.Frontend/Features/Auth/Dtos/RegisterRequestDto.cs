using System.ComponentModel.DataAnnotations;

namespace Microservices.Products.Frontend.Features.Auth.Dtos
{
    public class RegisterRequestDto
    {
        [Required]
        public string? Email { get; set; }

        public string? Role { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
