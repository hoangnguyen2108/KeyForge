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
                CreateAt = new DateTime(2025, 09, 05, 0, 0, 0, DateTimeKind.Utc),
                ExpiresAt = new DateTime(2025, 10, 05, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsTrial = true
            }, new ApiKeyClass
            {
                Id = 2,
                Key = "TEST - KEY - 1234567891",
                CreateAt = new DateTime(2025, 09, 05, 0, 0, 0, DateTimeKind.Utc),
                ExpiresAt = new DateTime(2025, 10, 05, 0, 0, 0, DateTimeKind.Utc),
                IsActive = false,
                IsTrial = true             
            }, new ApiKeyClass
            {
                // like to user admin
                Id = 3,
                Key = "TEST - KEY - WITHUSERAdmin - 1234567890",
                CreateAt = new DateTime(2025, 09, 05, 0, 0, 0, DateTimeKind.Utc),
                ExpiresAt = new DateTime(2025, 10, 05, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsTrial = true,
                UserId = "a4245943-934d-46eb-b3fa-123933f1f2bb"
            }, new ApiKeyClass
            {
                Id = 4,
                Key = "TEST - KEY - WITHUSERnormaluser - 1234567899",
                CreateAt = new DateTime(2025, 09, 05, 0, 0, 0, DateTimeKind.Utc),
                ExpiresAt = new DateTime(2025, 10, 05, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsTrial = true,
                UserId = "ecd01b95-943e-46be-9d56-9bc89b668f58"
            });
        }
    }
}
