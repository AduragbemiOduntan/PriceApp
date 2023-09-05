using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
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

        public async Task<StandardResponse<MaterialEstimateResponseDto>> CreatePegMEService( double buidingSetbackPermeter, string stage, int uniqueProjectId)
        {
            var peg = _unitOfWork.Product.GetPeg();
            MaterialEstimateRequestDto materialEstimateRequest = new MaterialEstimateRequestDto();
            //buidingSetbackPermeter and sectionDistance are in meter
            const byte sectionDistance = 3;
            const byte pegPerSectionDistance = 5;
            const byte minPegPerBundle = 15;

            //BSP is buildingSetBackPerimeter

            //Calculation for total peg bundle

            /*    var pegBundlePrice = peg.UnitPrice;*/
            var sectionDistanceInBSP = buidingSetbackPermeter / sectionDistance;
            var numOfPegInBSP = sectionDistanceInBSP * pegPerSectionDistance;
            var numOfPegBundle = numOfPegInBSP / minPegPerBundle;
            //Peg total cost
            var pegBundleTotalCost = numOfPegBundle * peg.UnitPrice;

            materialEstimateRequest.Name = peg.ProductName;
            materialEstimateRequest.UnitPrice = peg.UnitPrice;
            materialEstimateRequest.UnitOfMeasurement = peg.UnitOfMeasurement;
            materialEstimateRequest.Quantity = numOfPegBundle;
            materialEstimateRequest.TotalPrice = pegBundleTotalCost;
            materialEstimateRequest.Stage = stage;
            materialEstimateRequest.UniqueProjectId = uniqueProjectId;
            //Mapping
            _logger.LogInformation($"Attemping to create material estimate {DateTime.Now}");
            var newPegEst = _mapper.Map<MaterialEstimate>(materialEstimateRequest);
            _unitOfWork.MaterialEstimate.Create(newPegEst);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<MaterialEstimateResponseDto>(newPegEst);
            return StandardResponse<MaterialEstimateResponseDto>.Success($"Material estimate successfully created {newPegEst.Name}", productToReturn);
        }

        public async Task<StandardResponse<MaterialEstimateResponseDto>> GetMEByUniqueProjectIdAndStageAsync(int uniqueProjectId, string stage)
        {
            _logger.LogInformation($"Attemping to get material estimate {DateTime.Now}");
            
            var materialEstimate = await _unitOfWork.MaterialEstimate.GetMEByUniqueProjectIdAndStage(uniqueProjectId, stage);
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






        /*        public async Task<StandardResponse<MaterialEstimateResponseDto>> CreateMaterialEstimate(MaterialEstimateRequestDto materialEstimateRequest, double buildinSetbackPerimeter)
                {
                    if (materialEstimateRequest == null)
                    {
                        _logger.LogError("Material details cannot be empty");
                        return StandardResponse<MaterialEstimateResponseDto>.Failed("Material creation failed");
                    }

                    _logger.LogInformation($"Attemping to create a material estimate {DateTime.Now}");

                    if (materialEstimateRequest.Stage == "Setting-out")
                    {

                    }

                }

                public async Task<MaterialEstimateResponseDto> EstimateItemById(MaterialEstimateRequestDto materialRequest, int id, bool trackChanges)
                {
                    var material = _unitOfWork.MaterialEstimate.GetMaterialById(id, trackChanges);

                    var = _mapper.Map<MaterialEstimate>(materialRequest);


                    var materialEstimate = (double)material.UnitPrice * quantity;
                    return materialEstimate;

                }

                public Task<StandardResponse<EstimateItemResponseDto>> FoundationItemEstimate()
                {

                }
                public Task<StandardResponse<MaterialEstimateResponseDto>> SettingOutItemEstimate(double buidingSetbackPermeter)
                {
                    //buidingSetbackPermeter and sectionDistance are in meter
                    BuidingSetbackPermeter = buidingSetbackPermeter;
                    const byte sectionDistance = 3;
                    const byte pegPerSectionDistance = 5;
                    const byte minPegPerBundle = 15;

                    //BSP is buildingSetBackPerimeter

                    //Calculation for total peg bundle
                    var sectionDistanceInBSP = buidingSetbackPermeter / sectionDistance;
                    var numOfPegInBSP = sectionDistanceInBSP * pegPerSectionDistance;
                    var numOfPegBundle = numOfPegInBSP / minPegPerBundle;
                    //Peg cost
                    var coastOfPegBundle = _unitOfWork.EstimateItem.
                            var pegCost = numOfPegBundle * ;

                    //Calculation for total 

                }
            }*/
    }
}