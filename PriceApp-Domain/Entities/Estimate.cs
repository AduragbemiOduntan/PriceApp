using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class Estimate : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<MaterialEstimate> EstimatedItems { get; set; }
    }
}
