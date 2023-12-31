﻿using PriceApp_Domain.Dtos.Responses.materials;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationBaseCastingResponseDto
    {
        public string Section { get; set; } = "Sub-structure";
        public string Stage { get; set; }
        public MaterialDto SandDetails { get; set; }
        public MaterialDto CementDetails { get; set; }
        public MaterialDto GraniteDetails { get; set; }
        public double OverallTotalPrice { get; set; }

        public StripFoundationBaseCastingResponseDto()
        {
            SandDetails = new MaterialDto();
            CementDetails = new MaterialDto();
            GraniteDetails = new MaterialDto();
        }
    }
}
