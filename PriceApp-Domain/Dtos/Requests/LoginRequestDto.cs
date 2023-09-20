﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Domain.Dtos.Requests
{
    public class LoginRequestDto
    {

        [Required(ErrorMessage = "User name is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }

    }
}
