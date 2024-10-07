using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using resturant.api.Models;

namespace resturant.api.Data
{
    public class DefaultContext : IdentityDbContext<ApplicationUser>
    {
         public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }
    }
}