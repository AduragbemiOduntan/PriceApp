using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class ProductStatePriceDto
    {
        public double StateLowestPrice { get; set; }
        public double StateHighestPrice { get; set; }
        public double StateAveragePrice { get; set; }
    }
}
