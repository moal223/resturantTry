using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using resturant.api.Models;

namespace resturant.api.Data.mysql
{
    public class MySqlDbContext : IdentityDbContext<ApplicationUser>
    {
       public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure entity properties and relationships here if needed
    } 
    }
}