using Microsoft.EntityFrameworkCore;

namespace BasketApi.Models
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {

        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        // Override the OnModelCreating method 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}