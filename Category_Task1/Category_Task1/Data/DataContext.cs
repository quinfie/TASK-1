using Category_Task1.Entities;
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

        public DbSet<Order_Detail> Order_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Master Key Configuration for Order_Detail
            modelBuilder.Entity<Order_Detail>()
                .HasKey(od => od.Order_Detail_Id);

            // Other configurations if needed
        }
    }
}
