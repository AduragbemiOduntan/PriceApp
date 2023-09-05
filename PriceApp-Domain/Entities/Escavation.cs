using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class Escavation : BaseEntity
    {
        public double Girth { get; set; }
        public int uniqueProjectId { get; set; }
        public double PricePerMeter { get; set; }
        public double TotalPrice { get; set; }
    }
}
