using PriceApp_Domain.Dtos.Responses.materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationColumAndReinforcementResponseDto
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalCost { get; set; }

        public SandDto SandDetails { get; set; }
        public CementDto CementDetails { get; set; }
        public GraniteDto GraniteDetails { get; set; }
        public IronY10 IronY10Details { get; set; }
        public IronY16 IronY16Details { get; set; }
        public double TotalIronTonnage { get; set; }
        public double TotalIronCost { get; set; }
        public double WoodTotalCost { get; set; }
        public StripFoundationColumAndReinforcementResponseDto()
        {
            SandDetails = new SandDto();
            CementDetails = new CementDto();
            GraniteDetails = new GraniteDto();
            IronY10Details = new IronY10();
            IronY16Details = new IronY16();
        }
    }
}
