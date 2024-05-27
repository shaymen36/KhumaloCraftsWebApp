using Microsoft.EntityFrameworkCore;
using KhumaloCraftsWebApp.Models;
namespace KhumaloCraftsWebApp.Data
{
    using KhumaloCraftsWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class KhumaloCraftDBContext : DbContext
    {
        public KhumaloCraftDBContext(DbContextOptions<KhumaloCraftDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<KhumaloCraftsWebApp.Models.Customer> Customer { get; set; } = default!;

    }

}
