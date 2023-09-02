﻿using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IMaterialEstimateService
    {
        //Material Estimate for specific products
        Task<StandardResponse<MaterialEstimateResponseDto>> CreatePegMEService(double buidingSetbackPermeter, string stage);

        // General

    }
}
