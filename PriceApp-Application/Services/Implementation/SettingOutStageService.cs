using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.SeriviceMethods.Interfaces;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Implementation
{
    public class SettingOutStageService : ISettingOutStageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SettingOutStageService> _logger;
        private readonly IMapper _mapper;
        private ISettingOutMethods _settingOutMethods;

        public SettingOutStageService(IUnitOfWork unitOfWork, ILogger<SettingOutStageService> logger, IMapper mapper, ISettingOutMethods settingOutMethods)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _settingOutMethods = settingOutMethods;
        }



       /* public async Task<StandardResponse<SettingOutStageResponseDto>>  CreateSettingOutStageEstimate(SettingOutStageRequestDto settingOutStageRequest, double buildinSetbackPerimeter, int uniqueProjectId)
        {
            var settingOutEstimate = _settingOutMethods.SettingOutEstimate(buildinSetbackPerimeter, uniqueProjectId);

            settingOutStageRequest.Profile = settingOutEstimate.Profile;
            settingOutStageRequest.Peg = settingOutEstimate.Peg;
            settingOutStageRequest.Line = settingOutEstimate.Line;
            settingOutStageRequest.Nail = settingOutEstimate.Nail;
            settingOutStageRequest.TotalCostEstimate = settingOutEstimate.TotalCostEstimate;
            settingOutStageRequest.UniqueProjectId = uniqueProjectId;
            settingOutStageRequest.BuidingSetbackPermeter = buildinSetbackPerimeter;

            ////if (productRequest == null)
            ////{
            ////    _logger.LogError("Product details cannot be empty");
            ////    return StandardResponse<ProductResponseDto>.Failed("Product creation failed");
            ////}
            _logger.LogInformation($"Attemping to create setting-out stage estimate {DateTime.Now}");
            var newEstimate = _mapper.Map<SettingOutStage>(settingOutStageRequest);
            _unitOfWork.SettingOut.Create(newEstimate);
            await _unitOfWork.SaveAsync();
            var settingOutToReturn = _mapper.Map<SettingOutStageResponseDto>(newEstimate);
            return StandardResponse<SettingOutStageResponseDto>.Success($"Setting-out estimate successfully created", settingOutToReturn);

        }*/

/*        public Task<SettingOut> GetSettingOut(string id)
        {

        }*/
    }
}
