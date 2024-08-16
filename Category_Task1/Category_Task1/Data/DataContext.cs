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
    }
}
