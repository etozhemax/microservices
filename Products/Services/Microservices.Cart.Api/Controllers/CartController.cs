using Microservices.Cart.Api.Dtos;
using Microservices.Cart.Api.Helpers;
using Microservices.Cart.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Cart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController: ControllerBase
    {
        private readonly ICartService _productService;

        public CartController(ICartService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public async Task<ExecutionResult<IReadOnlyList<ProductDto>>> Get()
        //{
        //    ExecutionResult<IReadOnlyList<ProductDto>> result;

        //    try
        //    {
        //        var productDtos = await _productService.GetProducts();

        //        result = ExecutionResultHelper.CreateSuccessfulResult(productDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ExecutionResultHelper.CreateErrorResult<IReadOnlyList<ProductDto>>(ex.Message);
        //    }

        //    return result;
        //}

        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<ExecutionResult<ProductDto>> Get(int id)
        //{
        //    ExecutionResult<ProductDto> result;

        //    try
        //    {
        //        var productDto = await _productService.GetProductById(id);

        //        result = ExecutionResultHelper.CreateSuccessfulResult(productDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ExecutionResultHelper.CreateErrorResult<ProductDto>(ex.Message);
        //    }

        //    return result;
        //}

        //[HttpPost]
        //public async Task<ExecutionResult<ProductDto>> Add([FromBody] ProductDto productDto)
        //{
        //    ExecutionResult<ProductDto> result;

        //    try
        //    {
        //        var productDtoResult = await _productService.AddProduct(productDto);

        //        result = ExecutionResultHelper.CreateSuccessfulResult(productDtoResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ExecutionResultHelper.CreateErrorResult<ProductDto>(ex.Message);
        //    }

        //    return result;
        //}

        //[HttpPut]
        //public async Task<ExecutionResult<ProductDto>> Update([FromBody] ProductDto productDto)
        //{
        //    ExecutionResult<ProductDto> result;

        //    try
        //    {
        //        var productDtoResult = await _productService.UpdateProduct(productDto);

        //        result = ExecutionResultHelper.CreateSuccessfulResult(productDtoResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ExecutionResultHelper.CreateErrorResult<ProductDto>(ex.Message);
        //    }

        //    return result;
        //}

        //[HttpDelete]
        //[Route("{id:int}")]
        //public async Task<ExecutionResult<ProductDto>> Delete(int id)
        //{
        //    ExecutionResult<ProductDto> result;

        //    try
        //    {
        //        await _productService.DeleteProduct(id);

        //        result = ExecutionResultHelper.CreateSuccessfulResult<ProductDto>(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ExecutionResultHelper.CreateErrorResult<ProductDto>(ex.Message);
        //    }

        //    return result;
        //}
    }
}
