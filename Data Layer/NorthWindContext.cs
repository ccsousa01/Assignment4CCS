

using DataLayer.Model;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class NorthWindContext: DbContext
    {
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=northwind;user=root;password=CCSmys_01");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(c => new { c.OrderId, c.ProductId });               
        }

    }
}
