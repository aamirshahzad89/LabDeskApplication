using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LabDeskApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Log01InitialVendor> LogInitialVendor { get; set; }
        public DbSet<Log02InitialArticle> LogInitialArticle { get; set; }
        public DbSet<Log03InitialStyle> LogInitialStyle { get; set; }
        public DbSet<TestValues> TestValues { get; set; }
        public DbSet<TestApproach> TestApproach { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupVendor> SetupVendors { get; set; }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupProduct> SetupProducts { get; set; }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupArticleType> SetupArticleTypes { get; set; }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupColour> SetupColours { get; set; }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupUserInfo> SetupUserInfoes { get; set; }

        public System.Data.Entity.DbSet<LabDeskApplication.Models.SetupResult> SetupResults { get; set; }
    }
}