using resturant.api.Models;

namespace resturant.api.Services.Interfaces
{
    public interface ITokenGeneration
    {
        string GenerateAccess(ApplicationUser user);
    }
}