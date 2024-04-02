using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Auth.Dtos;

namespace Microservices.Products.Frontend.Features.Auth.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto<LoginResponseDto>?> Login(LoginRequestDto request);
        Task<ResponseDto<RegisterResponseDto>?> Register(RegisterRequestDto request);
        Task<ResponseDto<bool>?> AssignRole(RegisterRequestDto request);
    }
}
