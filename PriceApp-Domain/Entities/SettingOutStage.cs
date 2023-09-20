namespace PriceApp_Domain.Entities
{
    public class SettingOutStage : BaseEntity
    {
        public double PegDerivedEstimatedCost { get; set; }
        public double ProfileDerivedEstimatedCost { get; set; }
        public double LineDerivedEstimatedCost { get; set; }
        public double NailDerivedEstimatedCost { get; set; }
        public double BuidingSetbackPermeter { get; set; }

        public double TotalCostEstimate { get; set; }
        public string Appellation { get; set; }
        public ICollection<MaterialEstimate> MaterialEstimates { get; set; }
    }
}
