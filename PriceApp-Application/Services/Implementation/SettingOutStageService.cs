using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.materials;
using PriceApp_Domain.Entities;
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

        public async Task<StandardResponse<SettingOutStageResponseDto>> CreateSettingOutAsync(double buidingSetbackPerimeter, string stage, string state, string appellation)
        {
            const byte divisionFactor = 2;
            var pegs = await _unitOfWork.Product.FindProductByState("Peg", state);
            //buidingSetbackPermeter and sectionDistance are in meter
            const byte sectionDistance = 3;
            const byte pegPerSectionDistance = 5;
            const byte minPegPerBundle = 15;
            var peg = pegs.ToList().FirstOrDefault();
            //BSP is buildingSetBackPerimeter
            //Calculation for total peg bundle
            double sectionDistanceInBSP = buidingSetbackPerimeter / sectionDistance;
            double numOfPegInBSP = sectionDistanceInBSP * pegPerSectionDistance;
            double numOfPegBundle = numOfPegInBSP / minPegPerBundle;
            
            var pegEstimate = new MaterialDto();
            pegEstimate.ProductName = peg.ProductName;
            pegEstimate.UnitPrice = peg.UnitPrice;
            pegEstimate.UnitOfMeasurement = peg.UnitOfMeasurement;
            pegEstimate.Quantity = numOfPegBundle;
            pegEstimate.TotalCost = numOfPegBundle * peg.UnitPrice;
            pegEstimate.Stage = stage;
            pegEstimate.Appellation = appellation;
            //Mapping
            _logger.LogInformation($"Attemping to create material estimate {DateTime.Now}");
            var newPegEst = _mapper.Map<MaterialEstimate>(pegEstimate);
            _unitOfWork.MaterialEstimate.Create(newPegEst);
            await _unitOfWork.SaveAsync();

            double pegMaterialTotalCost = pegEstimate.TotalCost;
            double profileMaterialTotalCost = pegMaterialTotalCost / divisionFactor;
            double nailMaterialTotalCost = profileMaterialTotalCost / divisionFactor;
            double lineMaterialTotalCost = nailMaterialTotalCost / divisionFactor;

            var settingOutResuest = new SettingOutStageRequestDto();
            settingOutResuest.PegDerivedEstimatedCost = pegMaterialTotalCost;
            settingOutResuest.ProfileDerivedEstimatedCost = profileMaterialTotalCost;
            settingOutResuest.NailDerivedEstimatedCost = nailMaterialTotalCost;
            settingOutResuest.LineDerivedEstimatedCost= lineMaterialTotalCost;
            settingOutResuest.BuidingSetbackPermeter = buidingSetbackPerimeter;
            settingOutResuest.TotalCostEstimate = pegMaterialTotalCost + profileMaterialTotalCost + nailMaterialTotalCost + lineMaterialTotalCost;

            //Mapping
            _logger.LogInformation($"Attemping to create setting-out {DateTime.Now}");
            var newSettingOut = _mapper.Map<SettingOutStage>(settingOutResuest);
            _unitOfWork.SettingOut.Create(newSettingOut);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<SettingOutStageResponseDto>(newSettingOut);
            return StandardResponse<SettingOutStageResponseDto>.Success($"Setting-out successfully created", productToReturn);
        }

        public async Task<StandardResponse<SettingOutStageResponseDto>> GetSettingOutByAppellationAsync(string stage, string appellation)
        {
            _logger.LogInformation($"Attemping to get setting-out {DateTime.Now}");

            var settingOut = await _unitOfWork.SettingOut.GetSettingOutByUniqueProjectId(appellation);
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
    }
}