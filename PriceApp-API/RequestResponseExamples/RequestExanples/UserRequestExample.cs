using PriceApp_Domain.Dtos.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PriceApp_API.RequestResponseExamples.RequestExanples
{
    public class UserRequestExample : IExamplesProvider<UserRequestDto>
    {
        public UserRequestDto GetExamples()
        {
            return new UserRequestDto()
            { 
                FirstName = "Simisola",
                LastName =  "Ojooluwa",
                Email = "Ojoolu@example.com",
                Password = "JesusLovesYou",
            };
        }
    }
}
