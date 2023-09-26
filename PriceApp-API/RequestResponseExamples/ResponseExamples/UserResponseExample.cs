using PriceApp_Domain.Dtos.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PriceApp_API.RequestResponseExamples.ResponseExamples
{
    public class UserResponseExample : IExamplesProvider<UserResponseDto>
    {
        public UserResponseDto GetExamples()
        {
            return new UserResponseDto()
            {
                FirstName = "Simisola",
                LastName = "Ojooluwa",
                Email = "Ojoolu@example.com",
            }
            ;
        }
    }
}
