using Microsoft.EntityFrameworkCore;

namespace Microservices.Cart.Api.Data.Context
{
    public class CartDbContext: DbContext
    {
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }

        public CartDbContext(DbContextOptions<CartDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
