using Microservices.Products.Frontend.Configuration;
using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Products.Dtos;
using Microservices.Products.Frontend.Features.Products.Services.Interfaces;
using Microservices.Products.Frontend.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Microservices.Products.Frontend.Features.Products.Services
{
	public class ProductService : IProductService
    {
        private readonly IApiService _apiService;
        private readonly ProductApiOptions _options;

        public ProductService(IApiService apiService, IOptions<ProductApiOptions> options)
        {
            _apiService = apiService;
            _options = options.Value;
        }

        public async Task<ResponseDto<ProductDto>?> AddProduct(ProductDto couponDto)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl,
                Type = Utilities.Enums.HttpMethodType.Post,
                Data = couponDto
            };

            var response = await _apiService.SendAsync<ProductDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<ProductDto>?> DeleteProduct(int id)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + id,
                Type = Utilities.Enums.HttpMethodType.Delete,
            };

            var response = await _apiService.SendAsync<ProductDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<ProductDto>?> GetProductById(int id)
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl + id,
                Type = Utilities.Enums.HttpMethodType.Get,
            };

            var response = await _apiService.SendAsync<ProductDto>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<IReadOnlyList<ProductDto>>?> GetProducts()
        {
            var request = new RequestDto
            {
                Url = _options.Host + _options.ApiUrl,
                Type = Utilities.Enums.HttpMethodType.Get
            };

            var response = await _apiService.SendAsync<IReadOnlyList<ProductDto>>(request);

            return response ?? null;
        }

        public async Task<ResponseDto<ProductDto>?> UpdateProduct(ProductDto productDto)
        {
			var request = new RequestDto
			{
				Url = _options.Host + _options.ApiUrl,
				Type = Utilities.Enums.HttpMethodType.Put,
				Data = productDto
			};

			var response = await _apiService.SendAsync<ProductDto>(request);

			return response ?? null;
		}
    }
}
