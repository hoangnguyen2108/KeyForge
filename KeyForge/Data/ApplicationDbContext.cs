using KeyForge.Configuration;
using KeyForge.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using static System.Net.Mime.MediaTypeNames;

namespace KeyForge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApiKeyClass> ApiKeyClasses { get; set; }
        public DbSet<PaymentClass> PaymentClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApiKeyClass>()
                .HasOne(c => c.User)
                .WithMany(c => c.ApiKeys)
                .HasForeignKey(c => c.UserId);

            modelBuilder.ApplyConfiguration(new RoleNameConfig());
            modelBuilder.ApplyConfiguration(new AddUserConfig());
            modelBuilder.ApplyConfiguration(new ApiKeyClassConfig());              
            modelBuilder.ApplyConfiguration(new RolePositionConfig());
            modelBuilder.ApplyConfiguration(new AddNormalUserConfig());
        }
    }
}
