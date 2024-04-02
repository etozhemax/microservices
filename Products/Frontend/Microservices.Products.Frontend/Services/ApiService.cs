using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Auth.Services.Interfaces;
using Microservices.Products.Frontend.Services.Interfaces;
using Microservices.Products.Frontend.Utilities.Enums;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Microservices.Products.Frontend.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICookieTokenProvider _tokenProvider;

        public ApiService(
            IHttpClientFactory httpClientFactory,
            ICookieTokenProvider tokenProvider
            )
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto<T>?> SendAsync<T>(RequestDto request, bool withToken = true)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var httpRequestMessage = new HttpRequestMessage();

                httpRequestMessage.Headers.Add("Accept", "application/json");

                if (withToken)
                {
                    var token = _tokenProvider.GetToken();
                    httpRequestMessage.Headers.Add("Authorization", $"Bearer {token}");
                }

                var httpMethod = HttpMethod.Get;

                switch (request.Type)
                {
                    case HttpMethodType.Post:
                        httpMethod = HttpMethod.Post;
                        break;
                    case HttpMethodType.Put:
                        httpMethod = HttpMethod.Put;
                        break;
                    case HttpMethodType.Delete:
                        httpMethod = HttpMethod.Delete;
                        break;
                    default:
                        httpMethod = HttpMethod.Get;
                        break;
                }

                httpRequestMessage.Method = httpMethod;

                if (request.Data != null)
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                httpClient.BaseAddress = new Uri(request.Url);

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var response = new ResponseDto<T>();

                switch (httpResponseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        response.Success = false;
                        response.Message = "Not Found";
                        break;
                    case HttpStatusCode.Unauthorized:
                        response.Success = false;
                        response.Message = "Unauthorized";
                        break;
                    case HttpStatusCode.Forbidden:
                        response.Success = false;
                        response.Message = "Forbidden";
                        break;
                    case HttpStatusCode.InternalServerError:
                        response.Success = false;
                        response.Message = "Internal Server Error";
                        break;
                }

                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var content = httpResponseMessage.Content;

                    if (content != null)
                    {
                        var data = await content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<ResponseDto<T>>(data);
                    }
                }

                return response;
            }
            catch(Exception ex)
            {
                return new ResponseDto<T>()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
