using KeyForge.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyForge.Configuration
{
    public class ApiKeyClassConfig : IEntityTypeConfiguration<ApiKeyClass>
    {
        public void Configure(EntityTypeBuilder<ApiKeyClass> builder)
        {
            builder.HasData(new ApiKeyClass
            {
                Id = 1,
                Key = "TEST - KEY - 1234567890",
                CreateAt = DateTime.Now,
                ExpiresAt = DateTime.UtcNow.AddDays(30),
                IsActive = true,
                IsTrial = true
            }, new ApiKeyClass
            {
                Id = 2,
                Key = "TEST - KEY - 1234567891",
                CreateAt = DateTime.Now,
                ExpiresAt = DateTime.UtcNow.AddDays(30),
                IsActive = false,
                IsTrial = true
            });
        }
    }
}
