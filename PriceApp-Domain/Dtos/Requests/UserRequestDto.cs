using System.ComponentModel.DataAnnotations;

namespace PriceApp_Domain.Dtos.Requests
{
    public class UserRequestDto
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string Password { get; init; }

        /*        public string? FirstName { get; init; }
                public string? LastName { get; init; }
               *//* [Required(ErrorMessage = "Username is required")]*//*
                public string? UserName { get; init; }
                [Required(ErrorMessage = "Password is required")]
                public string? Password { get; init; }
                public string? Email { get; init; }
                public string? PhoneNumber { get; init; }
                public string UserType { get; set; }*/
    }
}
