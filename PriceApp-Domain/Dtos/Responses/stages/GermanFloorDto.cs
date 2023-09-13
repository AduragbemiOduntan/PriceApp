using PriceApp_Domain.Dtos.Responses.materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class GermanFloorDto
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalPrice { get; set; }

        public SandDto SandDetails { get; set; }
        public CementDto CementDetails { get; set; }
        public GraniteDto GraniteDetails { get; set; }
        public IronY12Dto IronY12Details { get; set;}

        public GermanFloorDto()
        {
            SandDetails = new SandDto();
            CementDetails = new CementDto();
            GraniteDetails = new GraniteDto();
            IronY12Details = new IronY12Dto();
        }
    }
}
