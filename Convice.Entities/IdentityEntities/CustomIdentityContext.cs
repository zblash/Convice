
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Convice.Entities.IdentityEntities
{
    public class CustomIdentityContext : IdentityDbContext<CustomIdentityUser,CustomIdentityRole,string>
    {
        public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options):base(options)
        {
            
        }
        
    }
}
