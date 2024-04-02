namespace Microservices.Products.Api.Dtos
{
    public class ExecutionResult<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
