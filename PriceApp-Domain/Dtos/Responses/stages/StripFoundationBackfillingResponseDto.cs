using PriceApp_Domain.Dtos.Responses.materials;

namespace PriceApp_Domain.Dtos.Responses.stages
{
    public class StripFoundationBackfillingResponseDto 
    {
        public string Section { get; set; } = "Sub-structure";
        public string Stage { get; set; }
        public MaterialDto LateriteDetails { get; set; }
        public double OverallTotalPrice { get; set; }

        public StripFoundationBackfillingResponseDto()
        {
            LateriteDetails = new MaterialDto();
        }
    }
}
