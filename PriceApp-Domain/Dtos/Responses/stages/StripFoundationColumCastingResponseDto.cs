﻿using PriceApp_Domain.Dtos.Responses.materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationColumCastingResponseDto
    {
        public string Section { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public double OverallTotalPrice { get; set; }

        public SandDto SandDetails { get; set; }
        public CementDto CementDetails { get; set; }
        public GraniteDto GraniteDetails { get; set; }

        public StripFoundationColumCastingResponseDto()
        {
            SandDetails = new SandDto();
            CementDetails = new CementDto();
            GraniteDetails = new GraniteDto();
        }
    }
}