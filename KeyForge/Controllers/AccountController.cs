using KeyForge.Data;
using KeyForge.DTO;
using KeyForge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyForge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ApplicationDbContext _context;

        public AccountController(IAuthManager authManager,ApplicationDbContext context)
        {
            _authManager = authManager;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register (ApiUserDtO apiUserDtO)
        {
            var update = await _authManager.Register(apiUserDtO);
            if (!update)
            {
                return BadRequest("Wrong");
            }
            return Ok("success");
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<LoginResponseDto> Login (LoginDtO loginDtO)
        {
            var update = await _authManager.Login(loginDtO);
            if (update == null)
            {
                return null;
            }
            return update;
        }

        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LoginResponseDto> RefreshToken(LoginResponseDto loginDto)
        {
            var result = await _authManager.VerifyRefreshToken(loginDto);
            if (result == null)
            {
                return null;
            }
            return result;

        }

    }
}
