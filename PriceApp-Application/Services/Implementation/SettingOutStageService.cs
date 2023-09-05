using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Domain.Enums;
using PriceApp_Infrastructure.UOW;

namespace PriceApp_Application.Services.Implementation
{
    public class SettingOutStageService : ISettingOutStageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SettingOutStageService> _logger;
        private readonly IMapper _mapper;

        public SettingOutStageService(IUnitOfWork unitOfWork, ILogger<SettingOutStageService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<StandardResponse<SettingOutStageResponseDto>> CreateSettingOutAsync(double buidingSetbackPerimeter, string stage, int uniqueProjectId)
        {
            const byte divisionFactor = 2;

            var pegEstimate = await _unitOfWork.MaterialEstimate.GetMEByUniqueProjectIdAndStage(uniqueProjectId, stage);

            var pegMaterialTotalCost = pegEstimate.TotalPrice;
            var profileMaterialTotalCost = pegMaterialTotalCost / divisionFactor;
            var nailMaterialTotalCost = profileMaterialTotalCost / divisionFactor;
            var lineMaterialTotalCost = nailMaterialTotalCost / divisionFactor;

            var settingOutResuest = new SettingOutStageRequestDto();

            settingOutResuest.PegDerivedEstimatedCost = pegMaterialTotalCost;
            settingOutResuest.ProfileDerivedEstimatedCost = profileMaterialTotalCost;
            settingOutResuest.NailDerivedEstimatedCost = nailMaterialTotalCost;
            settingOutResuest.LineDerivedEstimatedCost= lineMaterialTotalCost;
            settingOutResuest.BuidingSetbackPermeter = buidingSetbackPerimeter;
            settingOutResuest.UniqueProjectId = uniqueProjectId;
            
            settingOutResuest.TotalCostEstimate = pegMaterialTotalCost + profileMaterialTotalCost + nailMaterialTotalCost + lineMaterialTotalCost;

            //Mapping
            _logger.LogInformation($"Attemping to create setting-out with unique project ID {uniqueProjectId} {DateTime.Now}");
            var newSettingOut = _mapper.Map<SettingOutStage>(settingOutResuest);
            _unitOfWork.SettingOut.Create(newSettingOut);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<SettingOutStageResponseDto>(newSettingOut);
            return StandardResponse<SettingOutStageResponseDto>.Success($"Setting-out with unique project ID {newSettingOut.UniqueProjectId} successfully created", productToReturn);
        }

        public async Task<StandardResponse<SettingOutStageResponseDto>> GetSettingOutByProjectIdAsync(int uniqueProjectId)
        {
            _logger.LogInformation($"Attemping to get setting-out with unique project ID {uniqueProjectId} {DateTime.Now}");

            var settingOut = await _unitOfWork.SettingOut.GetSettingOutByUniqueProjectId(uniqueProjectId);
            var settingOutToReturn = _mapper.Map<SettingOutStageResponseDto>(settingOut);
            return StandardResponse<SettingOutStageResponseDto>.Success($"Setting-out successfully retrieved ", settingOutToReturn);
        }

        public async Task<StandardResponse<ICollection<SettingOutStageResponseDto>>> GetAllSettingOutAsync()
        {
            _logger.LogInformation($"Attemping to get setting-out {DateTime.Now}");

            var settingOut = _unitOfWork.SettingOut.FindAll(false);
            var settingOutToReturn = _mapper.Map<ICollection<SettingOutStageResponseDto>>(settingOut);
            return StandardResponse<ICollection<SettingOutStageResponseDto>>.Success($"Setting-out successfully retrieved ", settingOutToReturn);
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
