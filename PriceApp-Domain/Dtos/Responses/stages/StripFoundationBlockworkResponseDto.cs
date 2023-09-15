using PriceApp_Domain.Dtos.Responses.materials;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationBlockworkResponseDto
    {
        public string Section { get; set; } = "Sub-structure";
        public string Stage { get; set; }
        public MaterialDto SandDetails { get; set; }
        public MaterialDto CementDetails { get; set; }
        public MaterialDto Block9InchesDetails { get; set; }
        public double OverallTotalPrice { get; set; }

        public StripFoundationBlockworkResponseDto()
        {
            SandDetails = new MaterialDto();
            CementDetails = new MaterialDto();
            Block9InchesDetails = new MaterialDto();
        }
    }
}
