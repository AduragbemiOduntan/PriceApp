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
                    ProductName = "Sand",
                    Description = "Sharp sand",
                    UnitOfMeasurement = "Tonnage",
                    UnitPrice = 500000
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Cement",
                    Description = "Water proof",
                    UnitOfMeasurement = "Bag",
                    UnitPrice = 8000
                }
     /*            new Product
                 {
                     Id = 2,
                     ProductName = "Peg",
                     Description = "For building setting-out",
                     UnitOfMeasurement = "Tonnage",
                     UnitPrice = 2500
                 }*/
            );
        }
    }
}
