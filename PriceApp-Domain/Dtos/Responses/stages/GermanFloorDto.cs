﻿using PriceApp_Domain.Dtos.Responses.materials;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class GermanFloorDto
    {
        public string Section { get; set; } = "Sub-structure";
        public string Stage { get; set; }
        public MaterialDto SandDetails { get; set; }
        public MaterialDto CementDetails { get; set; }
        public MaterialDto GraniteDetails { get; set; }
        public MaterialDto IronY12Details { get; set;}
        public double WoodAndNailCost { get; set; }
        public MaterialDto NylonDetail { get; set; }
        public double OverallTotalPrice { get; set; }


        public GermanFloorDto()
        {
            SandDetails = new MaterialDto();
            CementDetails = new MaterialDto();
            GraniteDetails = new MaterialDto();
            IronY12Details = new MaterialDto();
            NylonDetail = new MaterialDto();
        }
    }
}
