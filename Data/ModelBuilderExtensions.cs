using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BakeryRazorPage.Models;

namespace BakeryRazorPage.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                    new Product 
                    {
                        ID = 1,
                        Name = "Big Ol' Cuppa",
                        Description = "For those who need more than a little pick-me-up",
                        Price = 8.99m,
                        ImageName = "bigolcup.jpg"
                    },
                    new Product
                    {
                        ID = 2,
                        Name = "Tiny Ol' Cuppa",
                        Description = "In case you need to cut back a little",
                        Price = 4.99m,
                        ImageName = "smallolcup.jpg"
                    },
                    new Product
                    {
                        ID = 3,
                        Name = "Literally a Big Gun",
                        Description = "What the!? How did this get here?",
                        Price = 999.99m,
                        ImageName = "agun.jpg"
                    }
                );
            return modelBuilder;
        }
    }
}
