using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.SeriviceMethods.Implementations;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;

namespace PriceApp_Application.Services.Implementation
{
    public class SubStructureEstimateService : ISubStructureEstimateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SubStructureEstimateService> _logger;
        private readonly IMapper _mapper;


        public SubStructureEstimateService(IUnitOfWork unitOfWork, ILogger<SubStructureEstimateService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StandardResponse<MaterialEstimateResponseDto>> GetSubStructureByAppelationAndStageAsync(string appellation, string stage)
        {
            _logger.LogInformation($"Attemping to get material estimate {DateTime.Now}");

            var materialEstimate = await _unitOfWork.MaterialEstimate.FindMaterialEstimateByAppelationAndStage(appellation, stage);
            var materialEstimateToReturn = _mapper.Map<MaterialEstimateResponseDto>(materialEstimate);
            return StandardResponse<MaterialEstimateResponseDto>.Success($"Material estimate successfully retrieved ", materialEstimateToReturn);
        }

        //Foundation-Base-Casting section
        public async Task<StandardResponse<StripFoundationBaseCastingResponseDto>> CreateFoundationBaseCastingAsync(double girth, string appellation)
        {
            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip");
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
            cementForFBC.Appellation = appellation;
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
            sandForFBC.Appellation = appellation;
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
            graniteForFBC.Appellation = appellation;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFBC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            foundationBaseCasting.OverallTotalPrice = cementForFBC.TotalCost + sandForFBC.TotalCost + graniteForFBC.TotalCost;
            //Look into creating each material on material table
            return StandardResponse<StripFoundationBaseCastingResponseDto>.Success($"Foundation base casting successfully created", foundationBaseCasting);
        }

        public async Task<StandardResponse<StripFoundationColumAndReinforcementResponseDto>> CreateFoundationColumnAndReinforcementAsync(double girth, string appellation)
        {
            var section = "Sub-structure";
            var stage = "Foundation";
            var subStage = "Strip Foundation Column and Reinforcement";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip");
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local");
            var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local");

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
            foundationColumnAndReinforcement.Stage = subStage;

            //Cement
            var cementForFCC = foundationColumnAndReinforcement.CementDetails;
            cementForFCC.ProductName = cement.ProductName;
            cementForFCC.UnitOfMeasurement = cement.UnitOfMeasurement;
            cementForFCC.UnitPrice = cement.UnitPrice;
            cementForFCC.Quantity = totalBagsOfCement;
            cementForFCC.TotalCost = totalBagsOfCement * cement.UnitPrice;
            cementForFCC.Stage = stage;
            cementForFCC.Appellation = appellation;
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
            sandForFCC.Appellation = appellation;
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
            graniteForFCC.Appellation = appellation;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForFCC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement
            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10FCR = foundationColumnAndReinforcement.IronY10Details;
            ironY10FCR.Appellation = appellation;
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
            ironY16FCR.Appellation = appellation;
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
                .Success($"Successful! {foundationColumnAndReinforcement.Stage} material cost estimate created", foundationColumnAndReinforcement);
        }

        public async Task<StandardResponse<StripFoundationBlockworkResponseDto>> CreateFoundationBlockWorkAsync(double girth, string appellation)
        {
            var stage = "Strip Foundation Blockwork";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var block = await _unitOfWork.Product.FindProductByName("9 Inches Block");

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
            cementForBW.Appellation = appellation;
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
            sandForBW.Appellation = appellation;
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
            blockForBW.Appellation = appellation;
            var createdBlock = _mapper.Map<MaterialEstimate>(blockForBW);
            _unitOfWork.MaterialEstimate.Create(createdBlock);
            await _unitOfWork.SaveAsync();

            foundationBlockwork.Stage = stage;
            foundationBlockwork.OverallTotalPrice = cementForBW.TotalCost
                + sandForBW.TotalCost + blockForBW.TotalCost;

            return StandardResponse<StripFoundationBlockworkResponseDto>
                .Success($"Successful {foundationBlockwork.Stage} created.", foundationBlockwork);
        }

        public async Task<StandardResponse<StripFoundationBackfillingResponseDto>> CreateFoundationBackfillingAsync(double buildingLength, double buildingBreath, string appellation)
        {
            var stage = "Strip Foundation Backfilling";
            var uniqueProjectId = 1;
            //laterite == filling sand
            var laterite = await _unitOfWork.Product.FindProductByName("Laterite 5 Ton Trip");

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
            lateriteBF.Appellation = appellation;
            lateriteBF.TotalCost = fiveTonnesSandTrip * laterite.UnitPrice;

            var createdLaterite = _mapper.Map<MaterialEstimate>(lateriteBF);
            _unitOfWork.MaterialEstimate.Create(createdLaterite);
            await _unitOfWork.SaveAsync();

            foundationBackfilling.Stage = stage;
            foundationBackfilling.OverallTotalPrice = lateriteBF.TotalCost;
            var foundationBF = _mapper.Map<StripFoundationBackfillingResponseDto>(foundationBackfilling);

            return StandardResponse<StripFoundationBackfillingResponseDto>
                .Success($"Successful {foundationBackfilling.Stage} created.", foundationBackfilling);
        }

        public async Task<StandardResponse<GermanFloorDto>> CreateGermanFloorAsync(double buildingLength, double buildingBreath, string appellation)
        {
            var stage = "German Floor";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip");
            var ironY12 = await _unitOfWork.Product.FindProductByName("Iron Y12 High Yield Local");
            /*            var wood = await _unitOfWork.Product.FindProductByName("", false);*/
            var nylon = await _unitOfWork.Product.FindProductByName("Nylon");

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
            cementForGF.Appellation = appellation;
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
            sandForGF.Appellation = appellation;
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
            graniteForGF.Appellation = appellation;
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
            ironY12GF.Appellation = appellation;
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
            nylonGF.Appellation = appellation;
            var nylonCreated = _mapper.Map<MaterialEstimate>(nylonGF);
            _unitOfWork.MaterialEstimate.Create(nylonCreated);
            await _unitOfWork.SaveAsync();

            germanFloorRequest.WoodAndNailCost = ironY12GF.TotalCost / 2;
            germanFloorRequest.OverallTotalPrice = sandForGF.TotalCost + cementForGF.TotalCost
                + graniteForGF.TotalCost + ironY12GF.TotalCost;
            return StandardResponse<GermanFloorDto>
                .Success($"Successful {germanFloorRequest.Stage} created.", germanFloorRequest);
        }
    }
}
