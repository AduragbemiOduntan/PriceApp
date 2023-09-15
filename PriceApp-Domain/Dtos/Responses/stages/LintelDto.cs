using PriceApp_Domain.Dtos.Responses.materials;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class LintelDto
    {
        public string Section { get; set; } = "super-structure";
        public string Stage { get; set; }
        public MaterialDto SandDetails { get; set; }
        public MaterialDto CementDetails { get; set; }
        public MaterialDto GraniteDetails { get; set; }
        public MaterialDto IronY10Details { get; set; }
        public MaterialDto IronY12Details { get; set; }
        public double WoodAndNailCost { get; set; }
        public double TotalIronTonnage { get; set; }
        public double TotalIronCost { get; set; }
        public double OverallTotalCost { get; set; }

        public LintelDto()
        {
            SandDetails = new MaterialDto();
            CementDetails = new MaterialDto();
            GraniteDetails = new MaterialDto();
            IronY10Details = new MaterialDto();
            IronY12Details = new MaterialDto();
        }
    }
}
