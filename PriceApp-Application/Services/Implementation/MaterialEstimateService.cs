using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;
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

        //Foundation-Base-Casting section
        public async Task<StandardResponse<FoundationBaseCastingResponseDto>> CreateFoundationBaseCastingAsync(double girth)
        {
            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var stage = "Foundation";
            var Section = "Sub-structure";
            var SubStage = "Foundation Base Casting";
            var uniqueProjectId = 1;


            const double escavatedTrenchWidth = 0.225;
            const double foundationBaseHeight = 0.225;
            const byte cementBagForOneVolumeOfConcreteMixture = 6;
            const double bucketFactorOne = 0.9;
            const double bucketFactorTwo = 1.4;


            double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight;
            double totalSandTonnage = volumeOfConcreteMixture * bucketFactorOne * bucketFactorTwo;
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = volumeOfConcreteMixture * cementBagForOneVolumeOfConcreteMixture;

            var foundationBaseCastingResponse = new FoundationBaseCastingResponseDto();
            foundationBaseCastingResponse.Section = Section;
            foundationBaseCastingResponse.Stage = stage;
            foundationBaseCastingResponse.SubStage = SubStage;

            //FBC is short for foundation base casting
            //Cement
            var cementForFBC = foundationBaseCastingResponse.CementDetails;
            cementForFBC.Name = cement.ProductName;
            cementForFBC.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForFBC.UnitPrice = cement.UnitPrice;
            cementForFBC.Quantity = totalBagsOfCement;
            cementForFBC.TotalPrice = totalBagsOfCement * cement.UnitPrice;
            cementForFBC.Stage = stage;
            cementForFBC.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForFBC);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();


            //Sand
            var sandForFBC = foundationBaseCastingResponse.SandDetails;
            sandForFBC.Name = sand.ProductName;
            sandForFBC.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForFBC.UnitPrice = sand.UnitPrice;
            sandForFBC.Quantity = totalSandTonnage;
            sandForFBC.TotalPrice = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
            sandForFBC.Stage = stage;
            sandForFBC.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForFBC);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteForFBC = foundationBaseCastingResponse.GraniteDetails;
            graniteForFBC.Name = granite.ProductName;
            graniteForFBC.UnitOfMeasurement= granite.UnitOfMeasurement;
            graniteForFBC.UnitPrice = granite.UnitPrice;
            graniteForFBC.Quantity = totalGraniteTonnage;
            graniteForFBC.TotalPrice = totalGraniteTonnage * granite.UnitPrice;
            graniteForFBC.Stage = stage;
            graniteForFBC.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFBC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            foundationBaseCastingResponse.OverallTotalPrice = cementForFBC.TotalPrice + sandForFBC.TotalPrice + graniteForFBC.TotalPrice;

            var foundationBC = _mapper.Map<FoundationBaseCastingResponseDto>(foundationBaseCastingResponse);

            //Look into creating each material on material table

            return StandardResponse<FoundationBaseCastingResponseDto>.Success($"Foundation base casting successfully created", foundationBaseCastingResponse);
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