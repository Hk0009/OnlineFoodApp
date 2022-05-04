using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrder.Models
{
    public class AppSecurityContext : IdentityDbContext<IdentityUser>
    {
        public AppSecurityContext(DbContextOptions<AppSecurityContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}