using Web1.Model;
using Microsoft.EntityFrameworkCore;

namespace Web1.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Category).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Unit).IsRequired().HasMaxLength(20);
                entity.Property(p => p.AvailableQuantity).IsRequired();
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasIndex(p => p.Category);
            });
        }
    }
}
