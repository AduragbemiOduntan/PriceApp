using Microsoft.AspNetCore.Identity;

namespace PriceApp_Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string? RefreshToken {  get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<MaterialEstimate> MaterialEstimate { get; set; }
    }
}