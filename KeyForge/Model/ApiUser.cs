using Microsoft.AspNetCore.Identity;

namespace KeyForge.Model
{
    public class ApiUser:IdentityUser
    {   
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<ApiKeyClass>? ApiKeys { get; set; }
    }
}
