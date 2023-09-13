using PriceApp_Domain.Dtos.Responses.materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationBackfillingResponseDto 
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalPrice { get; set; }
        public LateriteDto LateriteDetails { get; set; }

        public StripFoundationBackfillingResponseDto()
        {
            LateriteDetails = new LateriteDto();
        }
    }
}
