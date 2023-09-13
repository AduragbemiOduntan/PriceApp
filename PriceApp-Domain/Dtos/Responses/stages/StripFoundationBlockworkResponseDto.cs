using PriceApp_Domain.Dtos.Responses.materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationBlockworkResponseDto
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalPrice { get; set; }
        public SandDto SandDetails { get; set; }
        public CementDto CementDetails { get; set; }
        public Block9InchesDto Block9InchesDetails { get; set; }

        public StripFoundationBlockworkResponseDto()
        {
            SandDetails = new SandDto();
            CementDetails = new CementDto();
            Block9InchesDetails = new Block9InchesDto();
        }
    }
}
