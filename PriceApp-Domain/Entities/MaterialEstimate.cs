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

        public int UniqueProjectId { get; set; }

/*        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }*/


        /*        public string StageSection { get; set; }
                public int UniqueProjectId { get; set; } */

        /*        [ForeignKey(nameof(Product))]
                public int ProductId { get; set; }
                public Product Product { get; set; }*/

        /*        [ForeignKey(nameof(Estimate))]
                public int EstimateId { get; set; }
                public Estimate Estimate { get; set; }

                private Product _product;
                public MaterialEstimate(Product product)
                {
                    _product = product;
                }

                [Column(TypeName = "money")]
                public decimal UnitPrice => _product.UnitPrice;
                public string MaterialName => _product.ProductName;*/
    }
}
