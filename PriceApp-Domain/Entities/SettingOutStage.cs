using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class SettingOutStage : BaseEntity
    {
        [ForeignKey(nameof(MaterialEstimate))]
        public int MaterialEstimateId { get; set; }
        public MaterialEstimate Peg { get; set; }

        public double ProfileDerivedEstimatedCost { get; set; }
        public double LineDerivedEstimatedCost { get; set; }
        public double NailDerivedEstimatedCost { get; set; }
        public double BuidingSetbackPermeter { get; set; }

        public double TotalCostEstimate { get; set; }
        public int UniqueProjectId { get; set; }
        /*public ICollection<MaterialEstimate> MaterialEstimates { get; set; }*/
        /*
                [ForeignKey(nameof(Project))]
                public int ProjectId { get; set; }
                public Project Project { get; set; }
        */

    }
}
