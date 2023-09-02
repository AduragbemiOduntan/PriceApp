using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class CommonConstructionMaerial : BaseEntity
    {
        public double Cement { get; set; }
        public double Sand { get; set; }
        public double Iron { get; set; }
        public double Granite { get; set; }
        public double Wood { get; set; }
    }
}
