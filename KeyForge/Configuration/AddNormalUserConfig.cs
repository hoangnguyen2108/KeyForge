using KeyForge.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyForge.Configuration
{
    public class AddNormalUserConfig : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();

            var user = new ApiUser
            {
                Id = "ecd01b95-943e-46be-9d56-9bc89b668f58",
                UserName = "user2normal@gmail.com",
                NormalizedUserName = "USER2NORMAL@GMAIL.COM",
                Email = "user2normal@gmail.com",
                NormalizedEmail = "USER2NORMAL@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "User",
                LastName = "Normal"
            };
            user.PasswordHash = hasher.HashPassword(user, "Longbadao123@");
            builder.HasData(user);
        }
    }
}

