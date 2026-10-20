using Phone_Book.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phone_Book.API.Data;
using Asp.Versioning;
using Microsoft.AspNetCore.Http.HttpResults;
using BCrypt.Net;

namespace Phone_Book.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PhoneBookDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(PhoneBookDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("test")]
        public IActionResult Test()
        {
            return Ok(new { Message = "200 OK, Backend Connection has been established." });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            try
            {
                var username = register.Username;
                var email = register.Email;
                var password = register.Password;

                // Check if a user with the same email OR username already exists (case-insensitive)
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u =>  
                        EF.Functions.Like(u.Email.ToLower(), email.ToLower()) || EF.Functions.Like(u.Username.ToLower(), username.ToLower())
                    );
                
                if (existingUser != null)
                {
                    return Conflict(new { Message = "\nA user with the same email or username already exists." });
                }

                // Encrypt the password before storing it in the database
                string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                _context.Users.Add(new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = encryptedPassword
                });
                await _context.SaveChangesAsync();

                // Verify that the user was added successfully
                var addedUser = await _context.Users
                    .FirstOrDefaultAsync(u =>
                        EF.Functions.Like(u.Email.ToLower(), email.ToLower()) && EF.Functions.Like(u.Username.ToLower(), username.ToLower()) &&
                        EF.Functions.Like(u.PasswordHash, encryptedPassword)
                    );

                if (addedUser == null)
                {
                    return StatusCode(500, new { Message = "Failed to add the user to the database." });
                } 
                else
                {
                    return StatusCode(201, new { Message = "User registered successfully." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong with the server." });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            try
            {
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong with the server." });
            }
            return Ok(new { Message = "200 Ok" });
        }
    }
}
