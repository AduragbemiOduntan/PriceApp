using PriceApp_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public ICollection<MaterialEstimate> MaterialEstimate { get; set; }
    }
}
