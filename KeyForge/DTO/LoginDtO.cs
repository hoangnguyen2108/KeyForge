using System.ComponentModel.DataAnnotations;

namespace KeyForge.DTO
{
    public class LoginDtO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
