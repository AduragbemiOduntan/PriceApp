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
    public class SuperStructureEstimateService : ISuperStructureEstimateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SuperStructureEstimateService> _logger;
        private readonly IMapper _mapper;


        public SuperStructureEstimateService(IUnitOfWork unitOfWork, ILogger<SuperStructureEstimateService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StandardResponse<BuildingWallBlockworkDto>> CreateBuildingWallBlockWorkAsync(double girth, double buildingFloorHeight, string appellation)
        {
            var stage = "Building Wall Blockwork";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var block = await _unitOfWork.Product.FindProductByName("9 Inches Block");

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
            cementForBW.Appellation = appellation;
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
            sandForBW.Appellation = appellation;
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
            blockForBW.Appellation = appellation;
            var createdBlock = _mapper.Map<MaterialEstimate>(blockForBW);
            _unitOfWork.MaterialEstimate.Create(createdBlock);
            await _unitOfWork.SaveAsync();

            BuildingWall.Stage = stage;
            BuildingWall.OverallTotalPrice = cementForBW.TotalCost
                + sandForBW.TotalCost + blockForBW.TotalCost;

            return StandardResponse<BuildingWallBlockworkDto>
                .Success($"Successful {BuildingWall.Stage} created.", BuildingWall);
        }

        public async Task<StandardResponse<LintelDto>> CreateLintelAsync(double girth, string appellation)
        {
            var stage = "Wall Lintel";

            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip");
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local");
            var ironY12 = await _unitOfWork.Product.FindProductByName("Iron Y12 High Yield Local");
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
            cementForWL.Appellation = appellation;
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
            sandForWL.Appellation = appellation;
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
            graniteForWL.Appellation = appellation;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteForWL);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement


            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10WL = lintel.IronY10Details;
            ironY10WL.Appellation = appellation;
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
            ironY12WL.Appellation = appellation;
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

        public async Task<StandardResponse<BuildingWallColumnDto>> CreateWallColumnAsync(double girth, double wallHeight, string appellation)
        {
            var stage = "Strip Foundation Column and Reinforcement";
            var uniqueProjectId = 1;

            var cement = await _unitOfWork.Product.FindProductByName("Cement");
            var sand = await _unitOfWork.Product.FindProductByName("Sharp Sand 5 Ton Trip");
            var granite = await _unitOfWork.Product.FindProductByName("3/4 Granite 5 Ton Trip");
            var ironY10 = await _unitOfWork.Product.FindProductByName("Iron Y10 High Yield Local");
            var ironY16 = await _unitOfWork.Product.FindProductByName("Iron Y16 High Yield Local");


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
            cementWC.Appellation = appellation;
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
            sandWC.Appellation = appellation;
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
            graniteWC.Appellation = appellation;
            var createdGranite = _mapper.Map<MaterialEstimate>(graniteWC);
            _unitOfWork.MaterialEstimate.Create(createdGranite);
            await _unitOfWork.SaveAsync();

            //Reinforcement


            //FCR == foundation column reinforcement
            // Iron Y10
            var ironY10WC = wallColumn.IronY10Details;
            ironY10WC.Appellation = appellation;
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
            ironY16WC.Appellation = appellation;
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
                .Success($"Successful! {wallColumn.Stage} material cost estimate created", wallColumn);
        }
    }
}
