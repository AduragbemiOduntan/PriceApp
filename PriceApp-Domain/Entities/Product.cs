namespace PriceApp_Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double UnitPrice { get; set; }
        public string State { get; set; }
       /* public string? ImageUrl {  get; set; } */     
        public ICollection<MaterialEstimate> MaterialEstimate { get; set; }
    }
}
