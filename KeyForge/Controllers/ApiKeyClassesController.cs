using AutoMapper;
using KeyForge.Data;
using KeyForge.DTO;
using KeyForge.Model;
using KeyForge.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyForge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class ApiKeyClassesController : ControllerBase
    {
        private readonly IApiKeyClassService _apiKeyClassService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ApiKeyClassesController(IApiKeyClassService apiKeyClassService,IMapper mapper,ApplicationDbContext context)
        {
            _apiKeyClassService = apiKeyClassService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/ApiKeyClasses
        [HttpGet]
        public async Task<ActionResult<List<ApiKeyClass>>> GetApiKeyClasses()
        {
            var model = await _apiKeyClassService.GetAllViewAsync();
                          
            return Ok(model);
        }
        // GET: api/ApiKeyClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiKeyClass>> GetApiKeyClass(int id)
        {
            var apiKeyClass = await _apiKeyClassService.GetSingleKeyAsync(id);

            if (apiKeyClass == null)
            {
                return NotFound();
            }
            return apiKeyClass;
        }
        // PUT: api/ApiKeyClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApiKeyClass(int id, ApiKeyDTO apiKeyDTO)
        {
            await _apiKeyClassService.EditApiKeyClassAsync(id, apiKeyDTO);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/ApiKeyClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiKeyDTO>> PostApiKeyClass(ApiKeyDTO apiKeyDTO)
        {
            await _apiKeyClassService.CreateApiKeyClassAsync(apiKeyDTO);

            return RedirectToAction("GetApiKeyClasses");
        }
        // DELETE: api/ApiKeyClasses/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApiKeyClass(int id)
        {
            await _apiKeyClassService.DeleteApiKeyClass(id);

            return NoContent();
        }
        private bool ApiKeyClassExists(string key)
        {
            return _context.ApiKeyClasses.Any(e => e.Key == key);
        }
    }
}
