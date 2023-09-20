using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Responses
{
    public class UserResponseDto
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string Password { get; init; }
    }
}
