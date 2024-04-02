using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Coupon.Api.Data
{
    [Table("Coupons")]
    public class CouponEntity
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public required string CouponCode { get; set; }

        [Required]
        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
