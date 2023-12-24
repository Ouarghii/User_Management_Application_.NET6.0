using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using useManagementWithIdentity.Models;

namespace useManagementWithIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //new schema name security
            builder.Entity<ApplicationUser>()
                .ToTable("Users","security");
            builder.Entity<IdentityRole>()
                .ToTable("Roles","security");
            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles","security");
            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "security") ;
        }
    }
}