using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class ProjectDto
    {
        public List<MaterialEstimate> FoundationBaseCasting { get; set; }
        public List<MaterialEstimate> FoundationColumnAndReinforcement { get; set; }
        public List<MaterialEstimate> FoundationBlockwork { get; set; }
        public List<MaterialEstimate> FoundationBackfilling  { get; set; }
        public List<MaterialEstimate> GermanFloor { get; set; }
        public List<MaterialEstimate> WallColumn { get; set; }
    }
}
