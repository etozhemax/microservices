using Microservices.Products.Frontend.Dtos;

namespace Microservices.Products.Frontend.Services.Interfaces
{
    public interface IApiService
    {
        Task<ResponseDto<T>?> SendAsync<T>(RequestDto request, bool withToken = true);
    }
}
