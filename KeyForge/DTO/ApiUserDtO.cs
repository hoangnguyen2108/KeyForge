using System.ComponentModel.DataAnnotations;

namespace KeyForge.DTO
{
    public class ApiUserDtO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
