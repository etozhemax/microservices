using Microservices.Products.Frontend.Utilities.Enums;

namespace Microservices.Products.Frontend.Dtos
{
    public class RequestDto
    {
        public HttpMethodType Type { get; set; } = HttpMethodType.Get;
        public required string Url { get; set; }
        public object? Data { get; set; }
    }
}
