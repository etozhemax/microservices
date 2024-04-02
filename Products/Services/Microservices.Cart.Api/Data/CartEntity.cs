using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Cart.Api.Data
{
    [Table("Carts")]
    public class CartEntity
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public required string UserId { get; set; }

        public string? CouponCode { get; set; }

        [NotMapped]
        public double Discount { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }
    }
}
