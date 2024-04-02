namespace Microservices.Products.Frontend.Configuration
{
    public abstract class BaseApiOptions
    {
        public required string Host { get; set; }
        public required string ApiUrl { get; set; }
    }
}
