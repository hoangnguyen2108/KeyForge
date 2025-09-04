using KeyForge.DTO;
using KeyForge.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KeyForge.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IConfiguration configuration, UserManager<ApiUser> userManager)
        {
            _configuration = configuration;
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

        public async Task<LoginResponseDto> Login(LoginDtO loginDtO)
        {
            var model = await _userManager.FindByEmailAsync(loginDtO.Email);
            if (model == null)
            {
                return null;
            }
            var token = await GenerateToken(model);

            return new LoginResponseDto
            {
                Token = token,
                UserId = model.Id,
                RefreshToken = await CreateRefreshToken(model)
            };

        }

        public async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration
                ["JwtSettings:Key"]));

            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var roleclaims = roles.Select(c => new Claim(ClaimTypes.Role, c)).ToList();

            var userclaim = await _userManager.GetClaimsAsync(user);

            var claim = new List<Claim>
      {
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(JwtRegisteredClaimNames.Email, user.Email),
          new Claim("uid",user.Id),
      }
            .Union(userclaim).Union(roleclaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claim,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credential

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> CreateRefreshToken(ApiUser _user)
        {

            await _userManager.RemoveAuthenticationTokenAsync(_user, "HotelApiHosting_HoangEUF", "RefreshToken");
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, "HotelApiHosting_HoangEUF", "RefreshToken"); ;
            var result = await _userManager.SetAuthenticationTokenAsync(_user, "HotelApiHosting_HoangEUF", "RefreshToken", newRefreshToken);
            return newRefreshToken;

        }

        public async Task<LoginResponseDto> VerifyRefreshToken(LoginResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                return null;
            }

            var isValidToken = await _userManager.VerifyUserTokenAsync(
                user, "HotelListingApi", "RefreshToken", request.RefreshToken
            );

            if (!isValidToken)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                return null;
            }

            var newToken = await GenerateToken(user);

            return new LoginResponseDto
            {
                Token = newToken,
                UserId = user.Id,
                RefreshToken = await CreateRefreshToken(user)
            };
        }

    }
}
