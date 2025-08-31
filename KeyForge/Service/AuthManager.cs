using KeyForge.DTO;
using KeyForge.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace KeyForge.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> Register(ApiUserDtO apiUserDtO)
        {
            var model = new ApiUser()
            {
                Email = apiUserDtO.Email,
                UserName = apiUserDtO.Email,
                FirstName = apiUserDtO.FirstName,
                LastName = apiUserDtO.LastName,
            };

            var update = await _userManager.CreateAsync(model, apiUserDtO.Password);
            if (update.Succeeded)
            {
                await _userManager.AddToRoleAsync(model, "User");
                return true;
            }
            return false;

        }

        public async Task<bool> Login(LoginDtO loginDtO)
        {
            var model = await _userManager.FindByEmailAsync(loginDtO.Email);
            if (model == null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(model, loginDtO.Password);

        }

    }
}
