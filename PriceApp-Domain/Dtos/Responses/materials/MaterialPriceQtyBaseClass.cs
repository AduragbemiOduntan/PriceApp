using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.materials
{
    public class MaterialPriceQtyBaseClass
    {
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Stage { get; set; }
        public int UniqueProjectId { get; set; }
    }
}
