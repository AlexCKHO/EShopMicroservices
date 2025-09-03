using Discount.gRPC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Discount.gRPC.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        //What this line does in Entity Framework Core

        // Declares a table mapping

        //DbSet<T> tells EF Core: “This context works with a collection of entities of type Coupon.”

        //It doesn’t actually create the table by itself.

        //Instead, it maps the Coupon entity class to a database table.

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) {
        
        }

        //And what it does is hand off the database configuration (options) to
        //EF Core’s DbContext base class so your DiscountContext knows
        //how to connect to and query the database.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Discount", Amount = 150 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 }
                );
        }
    }
}
