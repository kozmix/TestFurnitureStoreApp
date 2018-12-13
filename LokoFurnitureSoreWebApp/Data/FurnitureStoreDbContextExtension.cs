using FurnitureStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureStoreWebApp.Data
{
    public static class FurnitureStoreExtension
    {
        public static void EnsureSeedDataForContext(this FurnitureStoreSqliteDbContext context)
        {
            //context.Database.EnsureCreated();
            if (context.Customers.Any())
            {
                return;
            }

            //init seed customers
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "First Important Customer",
                    IsPremium = true,
                    DateOfFirstPurchase = new DateTime(2017, 1, 09)
                },
                new Customer()
                {
                    Name = "Rovere",
                    IsPremium = true,
                    DateOfFirstPurchase = new DateTime(2017, 1, 29)
                },
                new Customer()
                {
                    Name = "Clean Mob",
                    IsPremium = false,
                    DateOfFirstPurchase = new DateTime(2018, 3, 29)
                },
                new Customer() {
                    Name = "Top Mob",
                    IsPremium = false,
                    DateOfFirstPurchase = new DateTime(2018, 1, 29)
                },
                new Customer()
                {
                    Name = "New New Client",
                    IsPremium = false,
                    DateOfFirstPurchase = DateTime.Now
                },
                new Customer()
                {
                    Name = "Mob XLux",
                    IsPremium = true,
                    DateOfFirstPurchase = DateTime.Now
                }
            };

            //init seet products
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Scaun Rolex",
                    Price = 15,
                    OnSale = false
                },
                new Product()
                {
                    Name = " Comoda Art",
                    Price = 25,
                    OnSale = false
                },
                new Product()
                {
                    Name = "Canapea Arthur",
                    Price = 35,
                    OnSale = true
                },
                new Product()
                {
                    Name = "Canapea Jones",
                    Price = 37,
                    OnSale = false

                },
                new Product()
                {
                    Name = "Masa Arthur",
                    Price = 24,
                    OnSale = true

                },
                new Product()
                {
                    Name = "Masa Jones",
                    Price = 25,
                    OnSale = false
                },
            };

            context.Customers.AddRange(customers);
            context.Products.AddRange(products);

            context.SaveChanges();
        }
    }
}
