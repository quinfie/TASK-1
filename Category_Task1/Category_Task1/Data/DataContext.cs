using Category_Task1.Entities;
using Category_Task1.Model;
using Microsoft.EntityFrameworkCore;

namespace Category_Task1.Data
{
    //Install package Microsoft.EntityFrameworkCore
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(dh => dh.OrderId);
                e.Property(dh => dh.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.EmployeeId);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => new { e.OrderId, e.ProductId }); // Composite key

                e.HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(e => e.Product)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");
            });
        }
    }
}
