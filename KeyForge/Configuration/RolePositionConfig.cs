using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyForge.Configuration
{
    public class RolePositionConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                UserId = "a4245943-934d-46eb-b3fa-123933f1f2bb",
                RoleId = "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b"
            });
        }
    }
}
