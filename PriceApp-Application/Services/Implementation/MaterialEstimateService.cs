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

        /*        public async Task<StandardResponse<MaterialEstimateResponseDto>> CreateMaterailEstimate(MaterialEstimateRequestDto materialEstimateRequest)
                {
                    if (materialEstimateRequest == null) { }
                    var materialEst = _mapper.Map<MaterialEstimate>(materialEstimateRequest);
                    _unitOfWork.MaterialEstimate.Create(materialEst);
                     await _unitOfWork.SaveAsync();
                    var materialEstCreated = _mapper.Map<MaterialEstimateResponseDto>(materialEst);

                    return StandardResponse<MaterialEstimateResponseDto>.Success($"Successful! {materialEstCreated.Name} created", materialEstCreated);
                }*/

        public async Task<StandardResponse<MaterialEstimateResponseDto>> CreatePegMEService(double buidingSetbackPermeter, string stage, int uniqueProjectId)
        {
            var peg = _unitOfWork.Product.GetPeg();
            MaterialEstimateRequestDto materialEstimate = new MaterialEstimateRequestDto();
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

            materialEstimate.Name = peg.ProductName;
            materialEstimate.UnitPrice = peg.UnitPrice;
            materialEstimate.UnitOfMeasurement = peg.UnitOfMeasurement;
            materialEstimate.Quantity = numOfPegBundle;
            materialEstimate.TotalPrice = pegBundleTotalCost;
            materialEstimate.Stage = stage;
            materialEstimate.UniqueProjectId = uniqueProjectId;
            //Mapping
            _logger.LogInformation($"Attemping to create material estimate {DateTime.Now}");
            var newPegEst = _mapper.Map<MaterialEstimate>(materialEstimate);
            _unitOfWork.MaterialEstimate.Create(newPegEst);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<MaterialEstimateResponseDto>(newPegEst);
            return StandardResponse<MaterialEstimateResponseDto>.Success($"Material estimate successfully created {newPegEst.ProductName}", productToReturn);
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
            var stage = "Strip Foundation Base Casting";

            var uniqueProjectId = 1;

            const double escavatedTrenchWidth = 0.675;
            const double foundationBaseHeight = 0.225;

            double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight;
            double totalSandTonnage = StaticMethods.SandTonnageInConcrete(volumeOfConcreteMixture);
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = StaticMethods.CementBagsInConcreteMixture(volumeOfConcreteMixture);

            var foundationBaseCasting = new StripFoundationBaseCastingResponseDto();
            foundationBaseCasting.Stage = stage;

            //FBC is short for foundation base casting
            //Cement
            var cementForFBC = foundationBaseCasting.CementDetails;
            cementForFBC.ProductName = cement.ProductName;
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
            var sandForFBC = foundationBaseCasting.SandDetails;
            sandForFBC.ProductName = sand.ProductName;
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
            var graniteForFBC = foundationBaseCasting.GraniteDetails;
            graniteForFBC.ProductName = granite.ProductName;
            graniteForFBC.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteForFBC.UnitPrice = granite.UnitPrice;
            graniteForFBC.Quantity = totalGraniteTonnage;
            graniteForFBC.TotalCost = totalGraniteTonnage * granite.UnitPrice;
            graniteForFBC.Stage = stage;
            graniteForFBC.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFBC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            foundationBaseCasting.OverallTotalPrice = cementForFBC.TotalCost + sandForFBC.TotalCost + graniteForFBC.TotalCost;
            //Look into creating each material on material table
            return StandardResponse<StripFoundationBaseCastingResponseDto>.Success($"Foundation base casting successfully created", foundationBaseCasting);
        }

        public async Task<StandardResponse<StripFoundationColumAndReinforcementResponseDto>> CreateFoundationColumnAndReinforcementAsync(double girth)
        {
            var section = "Sub-structure";
            var stage = "Foundation";
            var subStage = "Strip Foundation Column and Reinforcement";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local", false);
            var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local", false);

            const double columnWidth = 0.225;
            const double columnLength = 0.225;
            const double foundationHeight = 1.25;
            const double constantFactor = 0.15;
            /*   const double escavatedTrenchWidth = 0.225;*/
            /*  const double foundationBaseHeight = 0.225;*/
            /*  const double foundationHeight = 1.25;*/

            double numberOfColumn = girth / 3.0;
            double volumeOfOneColumnConcreteMixture = (numberOfColumn * (columnWidth * columnLength * foundationHeight));
            double totalVolumeOfColumnConcreteMixture = volumeOfOneColumnConcreteMixture * numberOfColumn;

            double totalSandTonnage = StaticMethods.SandTonnageInConcrete(totalVolumeOfColumnConcreteMixture);
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = StaticMethods.CementBagsInConcreteMixture(totalVolumeOfColumnConcreteMixture);

            //Look into this: volumeOfConcreteMixture same as vol. of foundation base of escavated area
            /*  double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight * foundationHeight;*/

            double totalIronTonnage = totalVolumeOfColumnConcreteMixture * constantFactor;
            double ironTonnageY10 = ((20 * totalIronTonnage) / 100);
            double ironTonnageY16 = totalIronTonnage - ironTonnageY10;

            //fCC: Foundation Column Casting
            var foundationColumnAndReinforcement = new StripFoundationColumAndReinforcementResponseDto();
            foundationColumnAndReinforcement.Section = section;
            foundationColumnAndReinforcement.Stage = stage;
            foundationColumnAndReinforcement.SubStage = subStage;

            //Cement
            var cementForFCC = foundationColumnAndReinforcement.CementDetails;
            cementForFCC.ProductName = cement.ProductName;
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
            var sandForFCC = foundationColumnAndReinforcement.SandDetails;
            sandForFCC.ProductName = sand.ProductName;
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
            var graniteForFCC = foundationColumnAndReinforcement.GraniteDetails;
            graniteForFCC.ProductName = granite.ProductName;
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
            var ironY10FCR = foundationColumnAndReinforcement.IronY10Details;
            ironY10FCR.UniqueProjectId = uniqueProjectId;
            ironY10FCR.ProductName = ironY10.ProductName;
            ironY10FCR.Stage = stage;
            ironY10FCR.UnitPrice = ironY10.UnitPrice;
            ironY10FCR.UnitOfMeasurement = ironY10.UnitOfMeasurement;
            ironY10FCR.Quantity = ironTonnageY10;
            ironY10FCR.TotalCost = ironTonnageY10 * ironY10.UnitPrice;
            var ironY10Created = _mapper.Map<MaterialEstimate>(ironY10FCR);
            _unitOfWork.MaterialEstimate.Create(ironY10Created);
            await _unitOfWork.SaveAsync();

            // Iron Y16
            var ironY16FCR = foundationColumnAndReinforcement.IronY16Details;
            ironY16FCR.UniqueProjectId = uniqueProjectId;
            ironY16FCR.ProductName = ironY16.ProductName;
            ironY16FCR.Stage = stage;
            ironY16FCR.UnitPrice = ironY16.UnitPrice;
            ironY16FCR.UnitOfMeasurement = ironY16.UnitOfMeasurement;
            ironY16FCR.Quantity = ironTonnageY16;
            ironY16FCR.TotalCost = ironTonnageY16 * ironY16.UnitPrice;
            var ironY16Created = _mapper.Map<MaterialEstimate>(ironY16FCR);
            _unitOfWork.MaterialEstimate.Create(ironY16Created);
            await _unitOfWork.SaveAsync();

            foundationColumnAndReinforcement.TotalIronTonnage = totalIronTonnage;
            foundationColumnAndReinforcement.TotalIronCost = ironY10FCR.TotalCost + ironY16FCR.TotalCost;
            foundationColumnAndReinforcement.WoodAndNailCost = foundationColumnAndReinforcement.TotalIronCost / 2;
            foundationColumnAndReinforcement.OverallTotalCost = cementForFCC.TotalCost + graniteForFCC.TotalCost 
                + sandForFCC.TotalCost + ironY10FCR.TotalCost + ironY16FCR.TotalCost + foundationColumnAndReinforcement.WoodAndNailCost;

            return StandardResponse<StripFoundationColumAndReinforcementResponseDto>
                .Success($"Successful! {foundationColumnAndReinforcement.SubStage} material cost estimate created", foundationColumnAndReinforcement);
        }

        public async Task<StandardResponse<StripFoundationBlockworkResponseDto>> CreateFoundationBlockWorkAsync(double girth)
        {
            var stage = "Strip Foundation Blockwork";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var block = await _unitOfWork.Product.FindProductByName("9 Inches Block", false);

            const double minimumFoundationHeight = 1.25;
            const byte numberOfBlocksInOneSquareMeter = 11;
            const byte numberOfBlocksToOneCementBag = 50;
            const byte numberOfSandWheelBarrowToOneCementBag = 3;
            const byte numberOfWheelBarrowInFiveTonnes = 35;

            var squareMeterOfBlockwork = girth * minimumFoundationHeight;
            var totalNumberOfBlock = squareMeterOfBlockwork * numberOfBlocksInOneSquareMeter;
            var totalBagsOfCement = totalNumberOfBlock / numberOfBlocksToOneCementBag;
            var totalSandWheelBarrow = totalBagsOfCement * numberOfSandWheelBarrowToOneCementBag;
            double fiveTonnesSandTrip = totalSandWheelBarrow / numberOfWheelBarrowInFiveTonnes;
            var totalSandInTonnes = fiveTonnesSandTrip * 5;
            var foundationBlockwork = new StripFoundationBlockworkResponseDto();

            //Cement
            var cementForBW = foundationBlockwork.CementDetails;
            cementForBW.ProductName = cement.ProductName;
            cementForBW.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForBW.UnitPrice = cement.UnitPrice;
            cementForBW.Quantity = totalBagsOfCement;
            cementForBW.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForBW.Stage = stage; //remember to change others to substage
            cementForBW.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForBW);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();

            //Sand
            var sandForBW = foundationBlockwork.SandDetails;
            sandForBW.ProductName = sand.ProductName;
            sandForBW.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForBW.UnitPrice = sand.UnitPrice;
            sandForBW.Quantity = totalSandInTonnes;
            sandForBW.TotalCost = fiveTonnesSandTrip * sand.UnitPrice; //look into the trailer tonnage
            sandForBW.Stage = stage;
            sandForBW.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForBW);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //Block
            var blockForBW = foundationBlockwork.Block9InchesDetails;
            blockForBW.ProductName = block.ProductName;
            blockForBW.UnitOfMeasurement = block.UnitOfMeasurement;
            blockForBW.UnitPrice = block.UnitPrice;
            blockForBW.Quantity = totalNumberOfBlock;
            blockForBW.TotalCost = totalNumberOfBlock * block.UnitPrice;
            blockForBW.Stage = stage;
            blockForBW.UniqueProjectId = uniqueProjectId;
            var createdBlock = _mapper.Map<MaterialEstimate>(blockForBW);
            _unitOfWork.MaterialEstimate.Create(createdBlock);
            await _unitOfWork.SaveAsync();

            foundationBlockwork.Stage = stage;
            foundationBlockwork.OverallTotalPrice = cementForBW.TotalCost 
                + sandForBW.TotalCost + blockForBW.TotalCost;

            return StandardResponse<StripFoundationBlockworkResponseDto>
                .Success($"Successful {foundationBlockwork.SubStage} created.", foundationBlockwork);
        }

        public async Task<StandardResponse<StripFoundationBackfillingResponseDto>> CreateFoundationBackfillingAsync(double buildingLength, double buildingBreath)
        {
            var stage = "Strip Foundation Backfilling";
            var uniqueProjectId = 1;
            //laterite == filling sand
            var laterite = await _unitOfWork.Product.FindProductByName("Laterite", false);

            const double minimumFoundationHeight = 1.25;
            const double squareMeterEquivalentToFiveTonnes = 3.53;

            double lateriteVolume = buildingLength * buildingBreath * minimumFoundationHeight;
            double fiveTonnesSandTrip = lateriteVolume / squareMeterEquivalentToFiveTonnes;
            double totalSandInTonnes = fiveTonnesSandTrip * 5;
            var foundationBackfilling = new StripFoundationBackfillingResponseDto();
           
            var lateriteBF = foundationBackfilling.LateriteDetails;
            lateriteBF.ProductName = laterite.ProductName;
            lateriteBF.UnitOfMeasurement = laterite.UnitOfMeasurement;
            lateriteBF.UnitPrice = laterite.UnitPrice;
            lateriteBF.Quantity = totalSandInTonnes;
            lateriteBF.Stage = stage;
            lateriteBF.UniqueProjectId = uniqueProjectId;
            lateriteBF.TotalCost = fiveTonnesSandTrip * laterite.UnitPrice;

            var createdLaterite = _mapper.Map<MaterialEstimate>(lateriteBF);
            _unitOfWork.MaterialEstimate.Create(createdLaterite);
            await _unitOfWork.SaveAsync();

            foundationBackfilling.Stage = stage;
            foundationBackfilling.OverallTotalPrice = lateriteBF.TotalCost;
            var foundationBF = _mapper.Map<StripFoundationBackfillingResponseDto>(foundationBackfilling);

            return StandardResponse<StripFoundationBackfillingResponseDto>
                .Success($"Successful {foundationBackfilling.SubStage} created.", foundationBackfilling);
        }

        public async Task<StandardResponse<GermanFloorDto>> CreateGermanFloorAsync(double buildingLength, double buildingBreath)
        {
            var stage = "German Floor";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var ironY12 = await _unitOfWork.Product.FindProductByName("Iron Y12 High Yield Local", false);
            /*            var wood = await _unitOfWork.Product.FindProductByName("", false);*/
            var nylon = await _unitOfWork.Product.FindProductByName("Nylon", false);

            const double floorThickness = 0.15;

            double germanFloorVolume = buildingLength * buildingBreath * floorThickness;
            double totalBagsOfCement = StaticMethods.CementBagsInConcreteMixture(germanFloorVolume);
            double totalSandTonnage = StaticMethods.SandTonnageInConcrete(germanFloorVolume);
            double fiveTonnesSandTrip = totalSandTonnage / 5;
            double totalGraniteTonnage = StaticMethods.GranitePercentInConcrete(totalSandTonnage);
            double fiveTonnesGraniteTrip = totalGraniteTonnage / 5;
            double totalIronTonnage = StaticMethods.IronTonnage(germanFloorVolume);

            var germanFloorRequest = new GermanFloorDto();

            //Cement
            var cementForGF = germanFloorRequest.CementDetails;
            cementForGF.ProductName = cement.ProductName;
            cementForGF.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForGF.UnitPrice = cement.UnitPrice;
            cementForGF.Quantity = totalBagsOfCement;
            cementForGF.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForGF.Stage = stage;
            cementForGF.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForGF);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();

            //Sand
            var sandForGF = germanFloorRequest.SandDetails;
            sandForGF.ProductName = sand.ProductName;
            sandForGF.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForGF.UnitPrice = sand.UnitPrice;
            sandForGF.Quantity = totalSandTonnage;
            sandForGF.TotalCost = fiveTonnesSandTrip * sand.UnitPrice; //look into the trailer tonnage
            sandForGF.Stage = stage;
            sandForGF.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForGF);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteForGF = germanFloorRequest.GraniteDetails;
            graniteForGF.ProductName = granite.ProductName;
            graniteForGF.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteForGF.UnitPrice = granite.UnitPrice;
            graniteForGF.Quantity = totalGraniteTonnage;
            graniteForGF.TotalCost = fiveTonnesGraniteTrip * granite.UnitPrice;
            graniteForGF.Stage = stage;
            graniteForGF.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForGF);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement

            //GF == german floor.
            // Iron Y12
            var ironY12GF = germanFloorRequest.IronY12Details;
            ironY12GF.ProductName = ironY12.ProductName;
            ironY12GF.UnitOfMeasurement = ironY12.UnitOfMeasurement;
            ironY12GF.UnitPrice = ironY12.UnitPrice;
            ironY12GF.Quantity = totalIronTonnage;
            ironY12GF.TotalCost = totalIronTonnage * ironY12.UnitPrice;
            ironY12GF.Stage = stage;
            ironY12GF.UniqueProjectId = uniqueProjectId;
            var ironY12Created = _mapper.Map<MaterialEstimate>(ironY12GF);
            _unitOfWork.MaterialEstimate.Create(ironY12Created);
            await _unitOfWork.SaveAsync();

            var nylonGF = germanFloorRequest.NylonDetail;
            nylonGF.ProductName = nylon.ProductName;
            nylonGF.UnitOfMeasurement = nylon.UnitOfMeasurement;
            nylonGF.UnitPrice = nylon.UnitPrice; //per m2
            nylonGF.Quantity = buildingLength * buildingBreath; //give m2 of nylon to be used.
            nylonGF.TotalCost = nylonGF.Quantity * nylon.UnitPrice;
            nylonGF.Stage = stage;
            nylonGF.UniqueProjectId = uniqueProjectId;
            var nylonCreated = _mapper.Map<MaterialEstimate>(nylonGF);
            _unitOfWork.MaterialEstimate.Create(nylonCreated);
            await _unitOfWork.SaveAsync();

            germanFloorRequest.WoodAndNailCost = ironY12GF.TotalCost / 2;
            germanFloorRequest.OverallTotalPrice = sandForGF.TotalCost + cementForGF.TotalCost 
                + graniteForGF.TotalCost + ironY12GF.TotalCost;
            return StandardResponse<GermanFloorDto>
                .Success($"Successful {germanFloorRequest.Stage} created.", germanFloorRequest);
        }

        public async Task<StandardResponse<BuildingWallBlockworkDto>> CreateBuildingWallBlockWorkAsync(double girth, double buildingFloorHeight)
        {
            var stage = "Building Wall Blockwork";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var block = await _unitOfWork.Product.FindProductByName("9 Inches Block", false);

            /*const double minimumFoundationHeight = 1.25;*/
            const byte numberOfBlocksInOneSquareMeter = 11;
            const byte numberOfBlocksToOneCementBag = 50;
            const byte numberOfSandWheelBarrowToOneCementBag = 3;
            const byte numberOfWheelBarrowInFiveTonnes = 35;

            double squareMeterOfBlockwork = girth * buildingFloorHeight;
            double totalNumberOfBlock = squareMeterOfBlockwork * numberOfBlocksInOneSquareMeter;
            double totalBagsOfCement = totalNumberOfBlock / numberOfBlocksToOneCementBag;
            double totalSandWheelBarrow = totalBagsOfCement * numberOfSandWheelBarrowToOneCementBag;
            double fiveTonnesSandTrip = totalSandWheelBarrow / numberOfWheelBarrowInFiveTonnes;
            double totalSandInTonnes = fiveTonnesSandTrip * 5;
            var BuildingWall = new BuildingWallBlockworkDto();

            //Cement
            var cementForBW = BuildingWall.CementDetails;
            cementForBW.ProductName = cement.ProductName;
            cementForBW.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForBW.UnitPrice = cement.UnitPrice;
            cementForBW.Quantity = totalBagsOfCement;
            cementForBW.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForBW.Stage = stage; //remember to change others to substage
            cementForBW.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForBW);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();

            //Sand
            var sandForBW = BuildingWall.SandDetails;
            sandForBW.ProductName = sand.ProductName;
            sandForBW.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForBW.UnitPrice = sand.UnitPrice;
            sandForBW.Quantity = totalSandInTonnes;
            sandForBW.TotalCost = fiveTonnesSandTrip * sand.UnitPrice; //look into the trailer tonnage
            sandForBW.Stage = stage;
            sandForBW.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForBW);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //Block
            var blockForBW = BuildingWall.Block9InchesDetails;
            blockForBW.ProductName = block.ProductName;
            blockForBW.UnitOfMeasurement = block.UnitOfMeasurement;
            blockForBW.UnitPrice = block.UnitPrice;
            blockForBW.Quantity = totalNumberOfBlock;
            blockForBW.TotalCost = totalNumberOfBlock * block.UnitPrice;
            blockForBW.Stage = stage;
            blockForBW.UniqueProjectId = uniqueProjectId;
            var createdBlock = _mapper.Map<MaterialEstimate>(blockForBW);
            _unitOfWork.MaterialEstimate.Create(createdBlock);
            await _unitOfWork.SaveAsync();

            BuildingWall.Stage = stage;
            BuildingWall.OverallTotalPrice = cementForBW.TotalCost 
                + sandForBW.TotalCost + blockForBW.TotalCost;

            return StandardResponse<BuildingWallBlockworkDto>
                .Success($"Successful {BuildingWall.SubStage} created.", BuildingWall);
        }

        public async Task<StandardResponse<LintelDto>> CreateLintelAsync(double girth)
        {
            var stage = "Wall Lintel";

            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local", false);
            var ironY12 = await _unitOfWork.Product.FindProductByName("Iron Y12 High Yield Local", false);
            /*var wood = await _unitOfWork.Product.FindProductByName("Wood", false);*/


            const double lintelWidth = 0.225;
            const double lintelLength = 0.225;
            /*const double foundationHeight = 1.25;*/
            const double constantFactor = 0.15;
            /*   const double escavatedTrenchWidth = 0.225;*/
            /*  const double foundationBaseHeight = 0.225;*/
            /*  const double foundationHeight = 1.25;*/

            var lintelConcreteMixtureVolume = girth * lintelLength * lintelWidth;
            double totalSandTonnage = StaticMethods.SandTonnageInConcrete(lintelConcreteMixtureVolume);
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = StaticMethods.CementBagsInConcreteMixture(lintelConcreteMixtureVolume);

            //Look into this: volumeOfConcreteMixture same as vol. of foundation base of escavated area
            /*  double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight * foundationHeight;*/

            double totalIronTonnage = lintelConcreteMixtureVolume * constantFactor;
            double ironTonnageY10 = ((20 * totalIronTonnage) / 100);
            double ironTonnageY12 = totalIronTonnage - ironTonnageY10;

            var lintel = new LintelDto();

            //Cement
            var cementForWL = lintel.CementDetails;
            cementForWL.ProductName = cement.ProductName;
            cementForWL.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForWL.UnitPrice = cement.UnitPrice;
            cementForWL.Quantity = totalBagsOfCement;
            cementForWL.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForWL.Stage = stage;
            cementForWL.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementForWL);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();


            //Sand
            var sandForWL = lintel.SandDetails;
            sandForWL.ProductName = sand.ProductName;
            sandForWL.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandForWL.UnitPrice = sand.UnitPrice;
            sandForWL.Quantity = totalSandTonnage;
            sandForWL.TotalCost = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
            sandForWL.Stage = stage;
            sandForWL.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandForWL);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteForWL = lintel.GraniteDetails;
            graniteForWL.ProductName = granite.ProductName;
            graniteForWL.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteForWL.UnitPrice = granite.UnitPrice;
            graniteForWL.Quantity = totalGraniteTonnage;
            graniteForWL.TotalCost = totalGraniteTonnage * granite.UnitPrice;
            graniteForWL.Stage = stage;
            graniteForWL.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForWL);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement


            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10WL = lintel.IronY10Details;
            ironY10WL.UniqueProjectId = uniqueProjectId;
            ironY10WL.ProductName = ironY10.ProductName;
            ironY10WL.Stage = stage;
            ironY10WL.UnitPrice = ironY10.UnitPrice;
            ironY10WL.UnitOfMeasurement = ironY10.UnitOfMeasurement;
            ironY10WL.Quantity = ironTonnageY10;
            ironY10WL.TotalCost = ironTonnageY10 * ironY10.UnitPrice;
            var ironY10Created = _mapper.Map<MaterialEstimate>(ironY10WL);
            _unitOfWork.MaterialEstimate.Create(ironY10Created);
            await _unitOfWork.SaveAsync();

            // Iron Y16
            var ironY12WL = lintel.IronY12Details;
            ironY12WL.UniqueProjectId = uniqueProjectId;
            ironY12WL.ProductName = ironY12.ProductName;
            ironY12WL.Stage = stage;
            ironY12WL.UnitPrice = ironY12.UnitPrice;
            ironY12WL.UnitOfMeasurement = ironY12.UnitOfMeasurement;
            ironY12WL.Quantity = ironTonnageY12;
            ironY12WL.TotalCost = ironTonnageY12 * ironY12.UnitPrice;
            var ironY16Created = _mapper.Map<MaterialEstimate>(ironY12WL);
            _unitOfWork.MaterialEstimate.Create(ironY16Created);
            await _unitOfWork.SaveAsync();

            lintel.TotalIronTonnage = totalIronTonnage;
            lintel.TotalIronCost = ironY10WL.TotalCost + ironY12WL.TotalCost;
            lintel.WoodAndNailCost = lintel.TotalIronCost / 2;

            lintel.OverallTotalCost =
                cementForWL.TotalCost + graniteForWL.TotalCost + sandForWL.TotalCost
                + ironY10WL.TotalCost + ironY12WL.TotalCost + lintel.WoodAndNailCost;

            return StandardResponse<LintelDto>
                .Success($"Successful! {lintel.Stage} material cost estimate created", lintel);
        }

        public async Task<StandardResponse<BuildingWallColumnDto>> CreateWallColumnAsync(double girth, double wallHeight)
        {
            var stage = "Strip Foundation Column and Reinforcement";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement", false);
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip", false);
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip", false);
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local", false);
            var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local", false);


            const double columnWidth = 0.225;
            const double columnLength = 0.225;
            const double constantFactor = 0.15;
            /*   const double escavatedTrenchWidth = 0.225;*/
            /*  const double foundationBaseHeight = 0.225;*/
            /*  const double foundationHeight = 1.25;*/

            double numberOfColumn = girth / 3.0;
            double volumeOfOneColumnConcreteMixture = (numberOfColumn * (columnWidth * columnLength * wallHeight));
            double totalVolumeOfColumnConcreteMixture = volumeOfOneColumnConcreteMixture * numberOfColumn;

            double totalSandTonnage = StaticMethods.SandTonnageInConcrete(totalVolumeOfColumnConcreteMixture);
            double totalGraniteTonnage = totalSandTonnage * 2;
            double totalBagsOfCement = StaticMethods.CementBagsInConcreteMixture(totalVolumeOfColumnConcreteMixture);

            //Look into this: volumeOfConcreteMixture same as vol. of foundation base of escavated area
            /*  double volumeOfConcreteMixture = girth * escavatedTrenchWidth * foundationBaseHeight * foundationHeight;*/

            double totalIronTonnage = totalVolumeOfColumnConcreteMixture * constantFactor;
            double ironTonnageY10 = ((20 * totalIronTonnage) / 100);
            double ironTonnageY16 = totalIronTonnage - ironTonnageY10;

            //fCC: Foundation Column Casting
            var wallColumn = new BuildingWallColumnDto();
            wallColumn.Stage = stage;

            //Cement
            var cementWC = wallColumn.CementDetails;
            cementWC.ProductName = cement.ProductName;
            cementWC.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementWC.UnitPrice = cement.UnitPrice;
            cementWC.Quantity = totalBagsOfCement;
            cementWC.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementWC.Stage = stage;
            cementWC.UniqueProjectId = uniqueProjectId;
            var createdCement = _mapper.Map<MaterialEstimate>(cementWC);
            _unitOfWork.MaterialEstimate.Create(createdCement);
            await _unitOfWork.SaveAsync();


            //Sand
            var sandWC = wallColumn.SandDetails;
            sandWC.ProductName = sand.ProductName;
            sandWC.UnitOfMeasurement = sand.UnitOfMeasurement;
            sandWC.UnitPrice = sand.UnitPrice;
            sandWC.Quantity = totalSandTonnage;
            sandWC.TotalCost = totalSandTonnage * sand.UnitPrice; //look into the trailer tonnage
            sandWC.Stage = stage;
            sandWC.UniqueProjectId = uniqueProjectId;
            var createdSand = _mapper.Map<MaterialEstimate>(sandWC);
            _unitOfWork.MaterialEstimate.Create(createdSand);
            await _unitOfWork.SaveAsync();

            //granite
            var graniteWC = wallColumn.GraniteDetails;
            graniteWC.ProductName = granite.ProductName;
            graniteWC.UnitOfMeasurement = granite.UnitOfMeasurement;
            graniteWC.UnitPrice = granite.UnitPrice;
            graniteWC.Quantity = totalGraniteTonnage;
            graniteWC.TotalCost = totalGraniteTonnage * granite.UnitPrice;
            graniteWC.Stage = stage;
            graniteWC.UniqueProjectId = uniqueProjectId;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteWC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement


            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10WC = wallColumn.IronY10Details;
            ironY10WC.UniqueProjectId = uniqueProjectId;
            ironY10WC.ProductName = ironY10.ProductName;
            ironY10WC.Stage = stage;
            ironY10WC.UnitPrice = ironY10.UnitPrice;
            ironY10WC.UnitOfMeasurement = ironY10.UnitOfMeasurement;
            ironY10WC.Quantity = ironTonnageY10;
            ironY10WC.TotalCost = ironTonnageY10 * ironY10.UnitPrice;
            var ironY10Created = _mapper.Map<MaterialEstimate>(ironY10WC);
            _unitOfWork.MaterialEstimate.Create(ironY10Created);
            await _unitOfWork.SaveAsync();

            // Iron Y16
            var ironY16WC = wallColumn.IronY16Details;
            ironY16WC.UniqueProjectId = uniqueProjectId;
            ironY16WC.ProductName = ironY16.ProductName;
            ironY16WC.Stage = stage;
            ironY16WC.UnitPrice = ironY16.UnitPrice;
            ironY16WC.UnitOfMeasurement = ironY16.UnitOfMeasurement;
            ironY16WC.Quantity = ironTonnageY16;
            ironY16WC.TotalCost = ironTonnageY16 * ironY16.UnitPrice;
            var ironY16Created = _mapper.Map<MaterialEstimate>(ironY16WC);
            _unitOfWork.MaterialEstimate.Create(ironY16Created);
            await _unitOfWork.SaveAsync();

            wallColumn.TotalIronTonnage = totalIronTonnage;
            wallColumn.TotalIronCost = ironY10WC.TotalCost + ironY16WC.TotalCost;
            wallColumn.WoodAndNailCost = wallColumn.TotalIronCost / 2;
            wallColumn.OverallTotalCost = cementWC.TotalCost + graniteWC.TotalCost + sandWC.TotalCost 
                + ironY10WC.TotalCost + ironY16WC.TotalCost + wallColumn.WoodAndNailCost;

            return StandardResponse<BuildingWallColumnDto>
                .Success($"Successful! {wallColumn.SubStage} material cost estimate created", wallColumn);
        }
    }
}