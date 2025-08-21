using KeyForge.DTO;
using KeyForge.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace KeyForge.Service
{
    public class AuthManager
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        
    }
}
