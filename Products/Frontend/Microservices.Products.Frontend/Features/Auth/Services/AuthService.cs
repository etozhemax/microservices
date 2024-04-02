using Microservices.Products.Frontend.Configuration;
using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Auth.Dtos;
using Microservices.Products.Frontend.Features.Auth.Services.Interfaces;
using Microservices.Products.Frontend.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Microservices.Products.Frontend.Features.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;
        private readonly AuthApiOptions _options;

        public AuthService(IApiService apiService, IOptions<AuthApiOptions> options)
        {
            _apiService = apiService;
            _options = options.Value;
        }

        public async Task<ResponseDto<bool>?> AssignRole(RegisterRequestDto request)
        {
            var requestDto = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + "assign",
                Type = Utilities.Enums.HttpMethodType.Post,
                Data = request
            };

            var response = await _apiService.SendAsync<bool>(requestDto);

            return response ?? null;
        }

        public async Task<ResponseDto<LoginResponseDto>?> Login(LoginRequestDto request)
        {
            var requestDto = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + "login",
                Type = Utilities.Enums.HttpMethodType.Post,
                Data = request
            };

            var response = await _apiService.SendAsync<LoginResponseDto>(requestDto);

            return response ?? null;
        }

        public async Task<ResponseDto<RegisterResponseDto>?> Register(RegisterRequestDto request)
        {
            var requestDto = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + "register",
                Type = Utilities.Enums.HttpMethodType.Post,
                Data = request
            };

            var response = await _apiService.SendAsync<RegisterResponseDto>(requestDto);

            return response ?? null;
        }
    }
}
