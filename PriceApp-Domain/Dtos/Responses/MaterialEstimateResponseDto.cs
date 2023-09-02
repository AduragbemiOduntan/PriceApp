using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class MaterialEstimateResponseDto
    {
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double UnitPrice { get; set; }

        public double Quantity { get; set; }
        public double TotalPrice { get; set; }

        public string Stage { get; set; }
    }
}
