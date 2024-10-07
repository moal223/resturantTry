
using Microsoft.AspNetCore.Identity;

namespace resturant.api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName {get; set;}
    }
}