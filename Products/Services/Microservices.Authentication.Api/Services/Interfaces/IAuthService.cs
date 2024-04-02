using Microservices.Authentication.Api.Dtos;

namespace Microservices.Authentication.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ExecutionResult<LoginResponseDto>> Login(LoginRequestDto request);
        Task<ExecutionResult<RegisterResponseDto>> Register(RegisterRequestDto request);
        Task<ExecutionResult<bool>> AssignRole(RegisterRequestDto request);
    }
}
