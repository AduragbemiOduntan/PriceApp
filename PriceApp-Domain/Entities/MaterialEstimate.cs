namespace PriceApp_Domain.Entities
{
    public class MaterialEstimate : BaseEntity
    {
        public string ProductName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Stage { get; set; }
        public string Appellation { get; set; }
    }
}
