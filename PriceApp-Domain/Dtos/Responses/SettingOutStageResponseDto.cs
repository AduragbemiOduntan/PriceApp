using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class SettingOutStageResponseDto
    {
        public double PegDerivedEstimatedCost { get; set; }
        public double ProfileDerivedEstimatedCost { get; set; }
        public double LineDerivedEstimatedCost { get; set; }
        public double NailDerivedEstimatedCost { get; set; }
        public double BuidingSetbackPermeter { get; set; }

        public double TotalCostEstimate { get; set; }
        public int UniqueProjectId { get; set; }
    }
}
