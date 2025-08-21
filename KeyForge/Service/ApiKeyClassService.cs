using AutoMapper;
using KeyForge.Data;
using KeyForge.DTO;
using KeyForge.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyForge.Service
{
    public class ApiKeyClassService : IApiKeyClassService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ApiKeyClassService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ApiKeyClass>> GetAllViewAsync()
        {
            var product = await _context.ApiKeyClasses.ToListAsync();
            var model = _mapper.Map<List<ApiKeyClass>>(product);

            return model;
        }

        public async Task<ApiKeyClass> GetSingleKeyAsync(int id)
        {
            var apiKeyClass = await _context.ApiKeyClasses.FindAsync(id);
            
            return apiKeyClass;
        }


        public async Task<bool> EditApiKeyClassAsync(int id, ApiKeyDTO apiKeyDTO)
        {
            var product = await _context.ApiKeyClasses.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            var model = _mapper.Map(apiKeyDTO, product);
            var checker = ApiKeyClassExists(apiKeyDTO.Key);
            if (checker == true)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateApiKeyClassAsync(ApiKeyDTO apiKeyDTO)
        {
            var model = _mapper.Map<ApiKeyClass>(apiKeyDTO);
            var checker = ApiKeyClassExists(apiKeyDTO.Key);
            if (checker == true)
            {
                return false;
            }
            await _context.ApiKeyClasses.AddAsync(model);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteApiKeyClass(int id)
        {
            var apiKeyClass = await _context.ApiKeyClasses.FindAsync(id);
            if (apiKeyClass == null)
            {
                return false;
            }

            _context.ApiKeyClasses.Remove(apiKeyClass);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ApiKeyClassExists(string key)
        {
            return _context.ApiKeyClasses.Any(e => e.Key == key);
        }
    }
}
