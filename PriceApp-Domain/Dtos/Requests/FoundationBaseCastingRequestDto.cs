using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Requests
{
    public class FoundationBaseCastingRequestDto
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalPrice { get; set; }

        public class Cement
        {
            public string Name { get; set; }
            public string UnitOfMeasurement { get; set; }
            public double UnitPrice { get; set; }
            public double Quantity { get; set; }
            public double TotalPrice { get; set; }
        }

        public class Sand
        {
            public string Name { get; set; }
            public string UnitOfMeasurement { get; set; }
            public double UnitPrice { get; set; }
            public double Quantity { get; set; }
            public double TotalPrice { get; set; }
        }

        public class Granite
        {
            public string Name { get; set; }
            public string UnitOfMeasurement { get; set; }
            public double UnitPrice { get; set; }
            public double Quantity { get; set; }
            public double TotalPrice { get; set; }
        }
    }
}
