using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApi.EfCore
{
    public class Ef_DataContext: DbContext
    {
        public Ef_DataContext(DbContextOptions<Ef_DataContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }//used to interact with the product table from the database
        public DbSet<Order> Orders { get; set; }//used to interact with the order table from the databse


    }
}
