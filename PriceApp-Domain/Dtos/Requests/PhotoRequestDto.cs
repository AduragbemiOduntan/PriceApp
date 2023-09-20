using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PriceApp_Domain.Dtos.Requests
{
    public class PhotoRequestDto
    {
            public string Url { get; set; }
            public IFormFile File { get; set; }
    }
}
