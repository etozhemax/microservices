using AutoMapper;
using Microservices.Products.Api.Data;
using Microservices.Products.Api.Data.Context;
using Microservices.Products.Api.Dtos;
using Microservices.Products.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Products.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(
            ProductDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            var productEntity = _mapper.Map<ProductEntity>(productDto);

            await _dbContext.Products.AddAsync(productEntity);

            await _dbContext.SaveChangesAsync();

            return productDto;
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (productEntity != null)
            {
                _dbContext.Products.Remove(productEntity);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var productEntity = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            var productDto = _mapper.Map<ProductDto>(productEntity);

            return productDto;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProducts()
        {
            var productEntities = await _dbContext.Products.ToListAsync();

            var productDtos = _mapper.Map<IReadOnlyList<ProductDto>>(productEntities);

            return productDtos;
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            var productEntity = _mapper.Map<ProductEntity>(productDto);

            _dbContext.Products.Update(productEntity);

            await _dbContext.SaveChangesAsync();

            return productDto;
        }
    }
}
