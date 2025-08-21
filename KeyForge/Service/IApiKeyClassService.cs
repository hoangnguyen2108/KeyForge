using KeyForge.DTO;
using KeyForge.Model;

namespace KeyForge.Service
{
    public interface IApiKeyClassService
    {
        Task<bool> CreateApiKeyClassAsync(ApiKeyDTO apiKeyDTO);
        Task<bool> DeleteApiKeyClass(int id);
        Task<bool> EditApiKeyClassAsync(int id, ApiKeyDTO apiKeyDTO);
        Task<List<ApiKeyClass>> GetAllViewAsync();
        Task<ApiKeyClass> GetSingleKeyAsync(int id);
    }
}