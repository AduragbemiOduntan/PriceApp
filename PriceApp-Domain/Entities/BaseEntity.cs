using System.ComponentModel.DataAnnotations;

namespace PriceApp_Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set;}
    }
}
