using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Infrastructure.UOW;

namespace PriceApp_Application.Services.Implementation
{
    public class MaterialEstimateService : IMaterialEstimateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MaterialEstimateService> _logger;
        private readonly IMapper _mapper;


        public MaterialEstimateService(IUnitOfWork unitOfWork, ILogger<MaterialEstimateService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StandardResponse<MaterialEstimateResponseDto>> GetMaterialEstimateByAppelationAndStageAsync(string appellation, string stage)
        {
            _logger.LogInformation($"Attemping to get material estimate {DateTime.Now}");

            var materialEstimate = await _unitOfWork.MaterialEstimate.FindMaterialEstimateByAppelationAndStage(appellation, stage);
            var materialEstimateToReturn = _mapper.Map<MaterialEstimateResponseDto>(materialEstimate);
            return StandardResponse<MaterialEstimateResponseDto>.Success($"Material estimate successfully retrieved ", materialEstimateToReturn);
        }

        public async Task<StandardResponse<ICollection<MaterialEstimateResponseDto>>> GetAllMaterialEstimateAsync()
        {
            _logger.LogInformation($"Attemping to get all material estimate {DateTime.Now}");

            var materialEstimates = _unitOfWork.MaterialEstimate.FindAll(false);
            var materialEstimateToReturn = _mapper.Map<ICollection<MaterialEstimateResponseDto>>(materialEstimates);
            return StandardResponse<ICollection<MaterialEstimateResponseDto>>.Success($"Material estimate successfully retrieved ", materialEstimateToReturn);
        }
    }
}