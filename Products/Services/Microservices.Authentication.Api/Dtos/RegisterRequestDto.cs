namespace Microservices.Authentication.Api.Dtos
{
    public class RegisterRequestDto
    {
        public required string Email { get; set; }
        public required string Role { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public required string Password { get; set; }
    }
}
