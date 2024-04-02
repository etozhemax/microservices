using Microservices.Products.Api.Dtos;

namespace Microservices.Products.Api.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IReadOnlyList<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int id);
        public Task<ProductDto> AddProduct(ProductDto couponDto);
        public Task<ProductDto> UpdateProduct(ProductDto couponDto);
        public Task DeleteProduct(int id);
    }
}
