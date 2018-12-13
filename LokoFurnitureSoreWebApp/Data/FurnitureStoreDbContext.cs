using FurnitureStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebApp.Data
{
    public class FurnitureStoreSqliteDbContext : DbContext
    {
        public FurnitureStoreSqliteDbContext(DbContextOptions<FurnitureStoreSqliteDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}
