using Microservices.Products.Api.Dtos;

namespace Microservices.Products.Api.Helpers
{
    public static class ExecutionResultHelper
    {
        public static ExecutionResult<T> CreateSuccessfulResult<T>(T? data)
        {
            return new ExecutionResult<T> { Data = data, Success = true };
        }

        public static ExecutionResult<T> CreateErrorResult<T>(string message)
        {
            return new ExecutionResult<T> { Data = default, Success = false, Message = message };
        }
    }
}
