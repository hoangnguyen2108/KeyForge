using KeyForge.DTO;
using KeyForge.Model;

namespace KeyForge.Service
{
    public interface IAuthManager
    {
        Task<string> CreateRefreshToken(ApiUser _user);
        Task<string> GenerateToken(ApiUser user);
        Task<LoginResponseDto> Login(LoginDtO loginDtO);
        Task<bool> Register(ApiUserDtO apiUserDtO);
        Task<LoginResponseDto> VerifyRefreshToken(LoginResponseDto request);
    }
}