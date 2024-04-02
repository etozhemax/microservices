using Microsoft.EntityFrameworkCore;

namespace Microservices.Coupon.Api.Data.Context
{
    public class CouponDbContext: DbContext
    {
        public DbSet<CouponEntity> Coupons { get; set; }

        public CouponDbContext(DbContextOptions<CouponDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponEntity>().HasData(
            [
                new CouponEntity() { CouponId = 1, CouponCode = "1", DiscountAmount = 200, MinAmount = 100 },
                new CouponEntity() { CouponId = 2, CouponCode = "2", DiscountAmount = 100, MinAmount = 50 },
                new CouponEntity() { CouponId = 3, CouponCode = "3", DiscountAmount = 50, MinAmount = 10 }
            ]);
        }
    }
}
