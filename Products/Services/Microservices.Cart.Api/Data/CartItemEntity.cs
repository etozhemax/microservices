using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microservices.Cart.Api.Dtos;

namespace Microservices.Cart.Api.Data
{
    [Table("CartItem")]
    public class CartItemEntity
    {
        [Key]
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public CartEntity Cart { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        public ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
