using KeyForge.Data;
using KeyForge.DTO;
using KeyForge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace KeyForge.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
      
        public ApiUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyKeys()
        {
            var userId = User.FindFirstValue("uid");
            var myKeys = await _context.ApiKeyClasses
                .Where(k => k.UserId == userId)
                .OrderByDescending(k => k.CreateAt)
                .Select(k => new
                {
                    k.Id,
                    k.Key,
                    k.IsTrial,
                    k.CreateAt,
                    k.ExpiresAt,
                    k.IsActive,
                    Status = !k.IsActive || k.ExpiresAt < DateTime.UtcNow ? "Expired" : "Active"
                })
                .ToListAsync();


            return Ok(myKeys);
        }

        [HttpPost("trial")]
        [ProducesResponseType(typeof(ApiKeyClassDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTrialKey()
        {
            var userId = User.FindFirstValue("uid");

            if(userId == null)
            {
                return BadRequest("Not Found User");
            }
            var existingTrial= await _context.ApiKeyClasses.FirstOrDefaultAsync(k => k.UserId == userId && k.IsTrial);
            if (existingTrial != null)
            {
                return BadRequest("You already used your free trial.");
            }
            var model = new ApiKeyClass
            {
                Key = Guid.NewGuid().ToString("N").Substring(0,20),
                CreateAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(5),
              //  IsActive = true,
                IsTrial = true,
                UserId = userId
            };

          
            _context.ApiKeyClasses.Add(model);
            await _context.SaveChangesAsync();

            var update = new ApiKeyClassDTO
            {
                Id = model.Id,
                Key = model.Key,
                CreateAt = model.CreateAt,
                ExpiresAt = model.ExpiresAt,
               // IsActive = model.IsActive,
                IsTrial = model.IsTrial,
                UserId = model.UserId
            };

            return Ok(update);
        }

    }
}
