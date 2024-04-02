using AutoMapper;
using Microservices.Cart.Api.Data;
using Microservices.Cart.Api.Data.Context;
using Microservices.Cart.Api.Dtos;
using Microservices.Cart.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Cart.Api.Services
{
    public class CartService : ICartService
    {
        private readonly CartDbContext _dbContext;
        private readonly IMapper _mapper;

        public CartService(
            CartDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //public async Task<ProductDto> AddProduct(ProductDto productDto)
        //{
        //    var productEntity = _mapper.Map<CartEntity>(productDto);

        //    await _dbContext.Products.AddAsync(productEntity);

        //    await _dbContext.SaveChangesAsync();

        //    return productDto;
        //}

        //public async Task DeleteProduct(int id)
        //{
        //    var productEntity = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

        //    if (productEntity != null)
        //    {
        //        _dbContext.Products.Remove(productEntity);

        //        await _dbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<ProductDto> GetProductById(int id)
        //{
        //    var productEntity = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

        //    var productDto = _mapper.Map<ProductDto>(productEntity);

        //    return productDto;
        //}

        //public async Task<IReadOnlyList<ProductDto>> GetProducts()
        //{
        //    var productEntities = await _dbContext.Products.ToListAsync();

        //    var productDtos = _mapper.Map<IReadOnlyList<ProductDto>>(productEntities);

        //    return productDtos;
        //}

        //public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        //{
        //    var productEntity = _mapper.Map<CartEntity>(productDto);

        //    _dbContext.Products.Update(productEntity);

        //    await _dbContext.SaveChangesAsync();

        //    return productDto;
        //}
    }
}
