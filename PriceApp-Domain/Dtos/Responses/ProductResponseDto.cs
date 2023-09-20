using PriceApp_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class ProductResponseDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal UnitPrice { get; set; }
        public string State { get; set; }
        /*public string ImageUrl { get; set; }*/
    }
}
