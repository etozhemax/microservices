using Microservices.Products.Frontend.Dtos;
using Microservices.Products.Frontend.Features.Products.Dtos;

namespace Microservices.Products.Frontend.Features.Products.Services.Interfaces
{
	public interface IProductService
    {
        public Task<ResponseDto<IReadOnlyList<ProductDto>>?> GetProducts();
        public Task<ResponseDto<ProductDto>?> GetProductById(int id);
        public Task<ResponseDto<ProductDto>?> AddProduct(ProductDto productDto);
        public Task<ResponseDto<ProductDto>?> UpdateProduct(ProductDto productDto);
        public Task<ResponseDto<ProductDto>?> DeleteProduct(int id);
    }
}
