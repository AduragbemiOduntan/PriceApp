using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Sharp Sand 5 Ton Trip",
                    Description = "Sharp sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 25000,
                    State = "Lagos"
                },
                new Product 
                {
                    Id = 2,
                    ProductName = "Sharp Sand 5 Ton Trip",
                    Description = "Sharp sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 27000,
                    State = "Delta"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Cement",
                    Description = "Water proof",
                    UnitOfMeasurement = "Bag",
                    UnitPrice = 4000,
                    State = "Lagos"
                },
                new Product 
                {
                    Id = 4,
                    ProductName = "Cement",
                    Description = "Water proof",
                    UnitOfMeasurement = "Bag",
                    UnitPrice = 4200,
                    State = "Delta"
                },
                new Product
                {
                     Id = 5,
                     ProductName = "3/4 Granite 5 Ton Trip",
                     Description = "Hard, granular stone used for construction",
                     UnitOfMeasurement = "Tonnage",
                     UnitPrice = 63400,
                     State = "Lagos"
                },
                new Product
                {
                    Id = 6,
                    ProductName = "3/4 Granite 5 Ton Trip",
                    Description = "Hard, granular stone used for construction",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 63600,
                    State = "Delta"
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Iron Y10 High Yield Local",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 350000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 8,
                     ProductName = "Iron Y10 High Yield Local",
                     Description = "",
                     UnitOfMeasurement = "Tonnage",
                     UnitPrice = 380000,
                     State = "Delta" 
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Iron Y12 High Yield Local",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 380000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 10,
                    ProductName = "Iron Y12 High Yield Local",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 380000,
                    State = "Delta"
                },
                new Product
                {
                    Id = 11,
                    ProductName = "Iron Y16 High Yield Local",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 380000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 12,
                    ProductName = "Iron Y16 High Yield Local",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 380000,
                    State = "Delta"
                },
                new Product
                {
                    Id = 13,
                    ProductName = "9 Inches Block",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 650,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 14,
                    ProductName = "9 Inches Block",
                    Description = "",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 700,
                    State = "Delta"
                },
                new Product
                {
                    Id = 15,
                    ProductName = "Laterite 5 Ton Trip",
                    Description = "Filling sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 6000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 16,
                    ProductName = "Laterite 5 Ton Trip",
                    Description = "Filling sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 7500,
                    State = "Delta"
                },
                new Product
                {
                    Id = 17,
                    ProductName = "Plaster Sand 5 Ton Trip",
                    Description = "Filling sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 5000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 18,
                    ProductName = "Plaster Sand 5 Ton Trip",
                    Description = "Filling sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 5500,
                    State = "Delta"
                },
                new Product
                {
                    Id = 19,
                    ProductName = "Peg",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 400,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 20,
                    ProductName = "Peg",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 450,
                    State = "Delta"
                }, 
                new Product
                {
                    Id = 21,
                    ProductName = "Profile",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 650,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 22,
                    ProductName = "Profile",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 650,
                    State = "Delta"
                },
                new Product
                {
                    Id = 23,
                    ProductName = "Line",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 900,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 24,
                    ProductName = "Line",
                    Description = "For setting-out",
                    UnitOfMeasurement = "Unit",
                    UnitPrice = 920,
                    State = "Delta"
                },
                new Product
                {
                    Id = 25,
                    ProductName = "Nail",
                    Description = "For wood work",
                    UnitOfMeasurement = "Bag",
                    UnitPrice = 4000,
                    State = "Lagos"
                },
                new Product
                {
                    Id = 26,
                    ProductName = "Nail",
                    Description = "For wood work",
                    UnitOfMeasurement = "Bag",
                    UnitPrice = 4000,
                    State = "Lagos"
                }
            );
        }
    }
}
