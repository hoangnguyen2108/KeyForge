using KeyForge.DTO;

namespace KeyForge.Service
{
    public interface IAuthManager
    {
        Task<bool> Login(LoginDtO loginDtO);
        Task<bool> Register(ApiUserDtO apiUserDtO);
    }
}