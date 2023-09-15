using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class Excavation : BaseEntity
    {
        public double Girth { get; set; }
        public int UniqueProjectId { get; set; }
        public double PricePerMeter { get; set; }
        public double TotalPrice { get; set; }
    }
}
