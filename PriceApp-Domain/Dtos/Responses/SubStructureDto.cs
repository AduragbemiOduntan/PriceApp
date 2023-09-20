using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class SubStructureDto
    {
        public List<MaterialEstimate> FoundationBaseCasting { get; set; }
        public List<MaterialEstimate> FoundationColumnAndReinforcement { get; set; }
        public List<MaterialEstimate> FoundationBlockwork { get; set; }
        public List<MaterialEstimate> FoundationBackfilling { get; set; }
        public List<MaterialEstimate> GermanFloor { get; set; }

        public SubStructureDto()
        {
            FoundationBaseCasting = new List<MaterialEstimate>();
            FoundationColumnAndReinforcement = new List<MaterialEstimate>();
            FoundationBlockwork = new List<MaterialEstimate>();
            FoundationBackfilling = new List<MaterialEstimate>();
            GermanFloor = new List<MaterialEstimate>();
        }
    }
}
