using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.SeriviceMethods.Implementations;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using static PriceApp_Domain.Dtos.Requests.FoundationBaseCastingRequestDto;

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

        public async Task<StandardResponse<MaterialEstimateResponseDto>> CreatePegMEService(double buidingSetbackPermeter, string stage, int uniqueProjectId)
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
        public async Task<StandardResponse<StripFoundationBaseCastingResponseDto>> CreateFoundationBaseCastingAsync(double girth)
        {
            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var stage = "Foundation";
            var section = "Sub-structure";
            var subStage = " Strip Foundation Base Casting";
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

            var foundationBaseCastingResponse = new StripFoundationBaseCastingResponseDto();
            foundationBaseCastingResponse.Section = section;
            foundationBaseCastingResponse.Stage = stage;
            foundationBaseCastingResponse.SubStage = subStage;

            //FBC is short for foundation base casting
            //Cement
            var cementForFBC = foundationBaseCastingResponse.CementDetails;
            cementForFBC.Name = cement.ProductName;
            cementForFBC.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForFBC.UnitPrice = cement.UnitPrice;
            cementForFBC.Quantity = totalBagsOfCement;
            cementForFBC.TotalCost = totalBagsOfCement * cement.UnitPrice;
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
            sandForFBC.TotalCost = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
            sandForFBC.Stage = stage;
            sandForFBC.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForFBC);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteForFBC = foundationBaseCastingResponse.GraniteDetails;
            graniteForFBC.Name = granite.ProductName;
            graniteForFBC.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteForFBC.UnitPrice = granite.UnitPrice;
            graniteForFBC.Quantity = totalGraniteTonnage;
            graniteForFBC.TotalCost = totalGraniteTonnage * granite.UnitPrice;
            graniteForFBC.Stage = stage;
            graniteForFBC.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFBC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            foundationBaseCastingResponse.OverallTotalPrice = cementForFBC.TotalCost + sandForFBC.TotalCost + graniteForFBC.TotalCost;

            var foundationBC = _mapper.Map<StripFoundationBaseCastingResponseDto>(foundationBaseCastingResponse);

            //Look into creating each material on material table

            return StandardResponse<StripFoundationBaseCastingResponseDto>.Success($"Foundation base casting successfully created", foundationBaseCastingResponse);
        }

        public async Task<StandardResponse<StripFoundationColumAndReinforcementResponseDto>> CreateFoundationColumnAndReinforcementAsync(double girth)
        {
            var section = "Sub-structure";
            var stage = "Foundation";
            var subStage = " Strip Foundation Column and Reinforcement";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local", false);
            var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local", false);


            const double width = 0.225;
            const double length = 0.225;
            const double foundationHeight = 1.25;
            const double constantFactor = 0.15;
         /*   const double escavatedTrenchWidth = 0.225;*/
          /*  const double foundationBaseHeight = 0.225;*/
          /*  const double foundationHeight = 1.25;*/

            double numberOfColumn = girth / 3.0;
            double volumeOfConcreteMixture = numberOfColumn * width * length * foundationHeight;

            double totalSandTonnage = StaticServiceMathods.SandPercentInConcrete(volumeOfConcreteMixture);
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = StaticServiceMathods.CementBagsInConcreteMixture(volumeOfConcreteMixture);

            //Look into this: volumeOfConcreteMixture same as vol. of foundation base of escavated area
            /*  double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight * foundationHeight;*/

            double totalIronTonnage = volumeOfConcreteMixture * constantFactor;
            double ironTonnageY10 = ((20 * totalIronTonnage) / 100);
            double ironTonnageY16 = totalIronTonnage - ironTonnageY10;

            //fCC: Foundation Column Casting
            var foundationColumnAndReinforcementRequest = new StripFoundationColumAndReinforcementResponseDto();
            foundationColumnAndReinforcementRequest.Section = section;
            foundationColumnAndReinforcementRequest.Stage = stage;
            foundationColumnAndReinforcementRequest.SubStage = subStage;

            //Cement
            var cementForFCC = foundationColumnAndReinforcementRequest.CementDetails;
            cementForFCC.Name = cement.ProductName;
            cementForFCC.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForFCC.UnitPrice = cement.UnitPrice;
            cementForFCC.Quantity = totalBagsOfCement;
            cementForFCC.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForFCC.Stage = stage;
            cementForFCC.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForFCC);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();


            //Sand
            var sandForFCC = foundationColumnAndReinforcementRequest.SandDetails;
            sandForFCC.Name = sand.ProductName;
            sandForFCC.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForFCC.UnitPrice = sand.UnitPrice;
            sandForFCC.Quantity = totalSandTonnage;
            sandForFCC.TotalCost = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
            sandForFCC.Stage = stage;
            sandForFCC.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForFCC);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteForFCC = foundationColumnAndReinforcementRequest.GraniteDetails;
            graniteForFCC.Name = granite.ProductName;
            graniteForFCC.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteForFCC.UnitPrice = granite.UnitPrice;
            graniteForFCC.Quantity = totalGraniteTonnage;
            graniteForFCC.TotalCost = totalGraniteTonnage * granite.UnitPrice;
            graniteForFCC.Stage = stage;
            graniteForFCC.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFCC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement
       

            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10FCR = foundationColumnAndReinforcementRequest.IronY10Details;
            ironY10FCR.UniqueProjectId = uniqueProjectId;
            ironY10FCR.Name = ironY10.ProductName;
            ironY10FCR.Stage = stage;
            ironY10FCR.UnitPrice = ironY10.UnitPrice;
            ironY10FCR.UnitOfMeasurement = ironY10.UnitOfMeasurement;
            ironY10FCR.Quantity = ironTonnageY10;
            ironY10FCR.TotalCost = ironTonnageY10 * ironY10.UnitPrice;
            var ironY10Created = _mapper.Map<MaterialEstimate>(ironY10FCR);
            _unitOfWork.MaterialEstimate.Create(ironY10Created);
            await _unitOfWork.SaveAsync();

            // Iron Y16
            var ironY16FCR = foundationColumnAndReinforcementRequest.IronY16Details;
            ironY16FCR.UniqueProjectId = uniqueProjectId;
            ironY16FCR.Name = ironY16.ProductName;
            ironY16FCR.Stage = stage;
            ironY16FCR.UnitPrice = ironY16.UnitPrice;
            ironY16FCR.UnitOfMeasurement = ironY16.UnitOfMeasurement;
            ironY16FCR.Quantity = ironTonnageY16;
            ironY16FCR.TotalCost = ironTonnageY16 * ironY16.UnitPrice;
            var ironY16Created = _mapper.Map<MaterialEstimate>(ironY16FCR);
            _unitOfWork.MaterialEstimate.Create(ironY16Created);
            await _unitOfWork.SaveAsync();

            foundationColumnAndReinforcementRequest.TotalIronTonnage = totalIronTonnage;
            foundationColumnAndReinforcementRequest.TotalIronCost = ironY10FCR.TotalCost + ironY16FCR.TotalCost;
            foundationColumnAndReinforcementRequest.OverallTotalCost = cementForFCC.TotalCost + graniteForFCC.TotalCost + sandForFCC.TotalCost + ironY16FCR.TotalCost + ironY16FCR.TotalCost;
            foundationColumnAndReinforcementRequest.WoodTotalCost = foundationColumnAndReinforcementRequest.TotalIronCost  / 2;
            foundationColumnAndReinforcementRequest.OverallTotalCost = cementForFCC.TotalCost + sandForFCC.TotalCost + graniteForFCC.TotalCost;

            var foundationCC = _mapper.Map<StripFoundationColumAndReinforcementResponseDto>(foundationColumnAndReinforcementRequest);

            return StandardResponse<StripFoundationColumAndReinforcementResponseDto>.Success($"Successful! {foundationColumnAndReinforcementRequest.SubStage} material cost estimate created", foundationCC);
        }

        //Material cost estimate for strip foundation reinforcement, including column.
        /* public async Task<StandardResponse<StripFoundationReinforcementResponseDto>> CreateFoundationReinforcementAsync(double girth)
         {
             var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local", false);
             var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local", false);
             *//* var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);*//*
             var section = "Sub-structure";
             var stage = "Foundation";
             var subStage = " Strip Foundation Reinforcement";
             var uniqueProjectId = 1;

             const double constantFactor = 0.15;
             const double escavatedTrenchWidth = 0.225;
             const double foundationBaseHeight = 0.225;
             const double foundationHeight = 1.25;

             //Look into this: volumeOfConcreteMixture same as vol. of foundation base of escavated area
             double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight * foundationHeight;

             double totalIronTonnage = volumeOfConcreteMixture * constantFactor;
             double ironTonnageY10 = ((20 * totalIronTonnage) / 100);
             double ironTonnageY16 = totalIronTonnage - ironTonnageY10;

             var foundationReignforcement = new StripFoundationReinforcementResponseDto();
             foundationReignforcement.Stage = stage;
             foundationReignforcement.Section = section;
             foundationReignforcement.SubStage = subStage;
             foundationReignforcement.TotalIronTonnage = totalIronTonnage;

             //FCR == foundation column reinforcement
             // Iron Y10
             var ironY10FCR = foundationReignforcement.IronY10Details;
             ironY10FCR.UniqueProjectId = uniqueProjectId;
             ironY10FCR.Name = ironY10.ProductName;
             ironY10FCR.Stage = stage;
             ironY10FCR.UnitPrice = ironY10.UnitPrice;
             ironY10FCR.UnitOfMeasurement = ironY10.UnitOfMeasurement;
             ironY10FCR.Quantity = ironTonnageY10;
             ironY10FCR.TotalCost = ironTonnageY10 * ironY10.UnitPrice;
             var ironY10Created = _mapper.Map<MaterialEstimate>(ironY10FCR);
             _unitOfWork.MaterialEstimate.Create(ironY10Created);
             await _unitOfWork.SaveAsync();

             // Iron Y16
             var ironY16FCR = foundationReignforcement.IronY16Details;
             ironY16FCR.UniqueProjectId = uniqueProjectId;
             ironY16FCR.Name = ironY16.ProductName;
             ironY16FCR.Stage = stage;
             ironY16FCR.UnitPrice = ironY16.UnitPrice;
             ironY16FCR.UnitOfMeasurement = ironY16.UnitOfMeasurement;
             ironY16FCR.Quantity = ironTonnageY16;
             ironY16FCR.TotalCost = ironTonnageY16 * ironY16.UnitPrice;
             var ironY16Created = _mapper.Map<MaterialEstimate>(ironY16FCR);
             _unitOfWork.MaterialEstimate.Create(ironY16Created);
             await _unitOfWork.SaveAsync();

             foundationReignforcement.OverallTotalCost = ironY16FCR.TotalCost + ironY16FCR.TotalCost;
             var foundationReignforcemnetCreated = _mapper.Map<StripFoundationReinforcementResponseDto>(foundationReignforcement);
             return StandardResponse<StripFoundationReinforcementResponseDto>.Success($"Successful! {foundationReignforcement.SubStage} material cost eatimate created", foundationReignforcemnetCreated);

         }*/


        //Material cost estimate for foundation column concrete and wood work
        /*        public async Task<StandardResponse<StripFoundationColumAndReinforcementResponseDto>> CreateFoundationColumCasting(double girth)
                {
                    var section = "Sub-structure";
                    var stage = "Foundation";
                    var subStage = " Strip Foundation Column Casting";
                    var uniqueProjectId = 1;

                    var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
                    var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
                    var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);


                    const double width = 0.225;
                    const double length = 0.225;
                    const double foundationHeight = 1.25;

                    double numberOfColumn = girth / 3.0;
                    double volumeOfConceteMixture = numberOfColumn * width * length * foundationHeight;

                    double totalSandTonnage = StaticServiceMathods.SandPercentInConcrete(volumeOfConceteMixture);
                    double totalGraniteTonnage = totalSandTonnage * 2;
                    double totalBagsOfCement = StaticServiceMathods.CementBagsInConcreteMixture(volumeOfConceteMixture);

                    //fCC: Foundation Column Casting
                    var foundationColumnCastingRequest = new StripFoundationColumAndReinforcementResponseDto();
                    foundationColumnCastingRequest.Section = section;
                    foundationColumnCastingRequest.Stage = stage;
                    foundationColumnCastingRequest.SubStage = subStage;

                    //Cement
                    var cementForFCC = foundationColumnCastingRequest.CementDetails;
                    cementForFCC.Name = cement.ProductName;
                    cementForFCC.UnitOfMeasurement = cement.UnitOfMeasurement;
                    cementForFCC.UnitPrice = cement.UnitPrice;
                    cementForFCC.Quantity = totalBagsOfCement;
                    cementForFCC.TotalCost = totalBagsOfCement * cement.UnitPrice;
                    cementForFCC.Stage = stage;
                    cementForFCC.UniqueProjectId = uniqueProjectId;
                    var createdCement = _mapper.Map<MaterialEstimate>(cementForFCC);
                    _unitOfWork.MaterialEstimate.Create(createdCement);
                    await _unitOfWork.SaveAsync();


                    //Sand
                    var sandForFCC = foundationColumnCastingRequest.SandDetails;
                    sandForFCC.Name = sand.ProductName;
                    sandForFCC.UnitOfMeasurement = sand.UnitOfMeasurement;
                    sandForFCC.UnitPrice = sand.UnitPrice;
                    sandForFCC.Quantity = totalSandTonnage;
                    sandForFCC.TotalCost = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
                    sandForFCC.Stage = stage;
                    sandForFCC.UniqueProjectId = uniqueProjectId;
                    var createdSand = _mapper.Map<MaterialEstimate>(sandForFCC);
                    _unitOfWork.MaterialEstimate.Create(createdSand);
                    await _unitOfWork.SaveAsync();

                    //granite
                    var graniteForFCC = foundationColumnCastingRequest.GraniteDetails;
                    graniteForFCC.Name = granite.ProductName;
                    graniteForFCC.UnitOfMeasurement = granite.UnitOfMeasurement;
                    graniteForFCC.UnitPrice = granite.UnitPrice;
                    graniteForFCC.Quantity = totalGraniteTonnage;
                    graniteForFCC.TotalCost = totalGraniteTonnage * granite.UnitPrice;
                    graniteForFCC.Stage = stage;
                    graniteForFCC.UniqueProjectId = uniqueProjectId;
                    var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFCC);
                    _unitOfWork.MaterialEstimate.Create(createdGranite);
                    await _unitOfWork.SaveAsync();

                    var foundationReinforcement = await CreateFoundationReinforcementAsync(girth);
                   *//* double woodtotalCost = foundationReinforcement.Data.OverallTotalPrice / 2;*//*

                    foundationColumnCastingRequest.OverallTotalCost = cementForFCC.TotalCost + sandForFCC.TotalCost + graniteForFCC.TotalCost;

                    var foundationCC = _mapper.Map<StripFoundationColumAndReinforcementResponseDto>(foundationColumnCastingRequest);

                    //Look into creating each material on material table

                    return StandardResponse<StripFoundationColumAndReinforcementResponseDto>.Success($"Successful! {foundationColumnCastingRequest.SubStage} material created", foundationCC);
                }*/





        /*     public async Task<StandardResponse<MaterialEstimateResponseDto>> CreateMaterialEstimate(MaterialEstimateRequestDto materialEstimateRequest, double buildinSetbackPerimeter)
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
*/
    }
}