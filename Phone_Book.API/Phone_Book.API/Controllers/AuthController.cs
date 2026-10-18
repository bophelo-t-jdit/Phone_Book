using Phone_Book.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phone_Book.API.Data;
using Asp.Versioning;

namespace Phone_Book.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly PhoneBookDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(PhoneBookDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("test")]
        public IActionResult Test()
        {
            return Ok(new { Message = "200 OK, Backend Connection has been established." });
        }
    }
}
