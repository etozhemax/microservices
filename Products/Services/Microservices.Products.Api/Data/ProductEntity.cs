using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Products.Api.Data
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public required double Price { get; set; }

        public string Description { get; set; }

        [Required]
        public required string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
