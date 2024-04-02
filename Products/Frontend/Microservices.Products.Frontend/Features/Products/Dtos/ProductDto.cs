namespace Microservices.Products.Frontend.Features.Products.Dtos
{
    public class ProductDto
    {
		public int ProductId { get; set; }
		public required string Name { get; set; }
		public required double Price { get; set; }
		public string Description { get; set; }
		public required string CategoryName { get; set; }
		public string ImageUrl { get; set; }
	}
}
