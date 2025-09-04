using KeyForge.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

       

    }
}
