using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeyForge.Data;
using KeyForge.Model;
using KeyForge.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using KeyForge.Service;

namespace KeyForge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var product = await _context.ApiKeyClasses.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _mapper.Map(apiKeyDTO, product);
            var checker = ApiKeyClassExists(apiKeyDTO.Key);
            if(checker == true)
            {
                return BadRequest();
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/ApiKeyClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiKeyDTO>> PostApiKeyClass(ApiKeyDTO apiKeyDTO)
        {
            var model = _mapper.Map<ApiKeyClass>(apiKeyDTO);
            var checker = ApiKeyClassExists(apiKeyDTO.Key);
            if (checker == true)
            {
                return BadRequest();
            }
            await _context.ApiKeyClasses.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApiKeyClasses", new { key = model.Key }, model);
        }
        // DELETE: api/ApiKeyClasses/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApiKeyClass(int id)
        {
            var apiKeyClass = await _context.ApiKeyClasses.FindAsync(id);
            if (apiKeyClass == null)
            {
                return NotFound();
            }

            _context.ApiKeyClasses.Remove(apiKeyClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ApiKeyClassExists(string key)
        {
            return _context.ApiKeyClasses.Any(e => e.Key == key);
        }
    }
}
