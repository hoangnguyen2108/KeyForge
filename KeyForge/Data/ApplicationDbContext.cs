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

            modelBuilder.Entity<ApiKeyClass>().HasData(new ApiKeyClass
            {
                Id = 1,
                Key = "TEST - KEY - 1234567890",
                CreateAt = DateTime.Now,
                ExpiresAt = DateTime.UtcNow.AddDays(30),
                IsActive = true
            }, new ApiKeyClass
            {
                Id = 2,
                Key = "TEST - KEY - 1234567891",
                CreateAt = DateTime.Now,
                ExpiresAt = DateTime.UtcNow.AddDays(30),
                IsActive = false
            });
        }
    }
}
