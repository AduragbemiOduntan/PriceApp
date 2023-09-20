using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Entities
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public Byte IsMain { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
   
        public string ProductId { get; set; }
    }
}
