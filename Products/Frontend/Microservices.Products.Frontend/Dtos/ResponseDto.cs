using System.Text.Json.Serialization;

namespace Microservices.Products.Frontend.Dtos
{
    public class ResponseDto<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }

		[JsonPropertyName("message")]
		public string? Message { get; set; }
    }
}
