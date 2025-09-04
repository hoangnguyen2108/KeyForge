using KeyForge.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyForge.Configuration
{
    public class AddUserConfig : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();

            var user = new ApiUser
            {
                Id = "a4245943-934d-46eb-b3fa-123933f1f2bb",
                UserName = "user2sup@gmail.com",
                NormalizedUserName = "USER2SUP@GMAIL.COM",
                Email = "user2sup@gmail.com",
                NormalizedEmail = "USER2SUP@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "John",
                LastName = "Doe"
            };

            user.PasswordHash = hasher.HashPassword(user, "Longbadao123@");

            builder.HasData(user);
        }
    }
}
