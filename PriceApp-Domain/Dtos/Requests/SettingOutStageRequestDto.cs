using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Requests
{
    public class SettingOutStageRequestDto
    {
        public MaterialEstimate Profile { get; set; }
        public MaterialEstimate Peg { get; set; }
        public MaterialEstimate Line { get; set; }
        public MaterialEstimate Nail { get; set; }
        public double BuidingSetbackPermeter { get; set; }

        public double TotalCostEstimate { get; set; }
        public int UniqueProjectId { get; set; }
    }
}
