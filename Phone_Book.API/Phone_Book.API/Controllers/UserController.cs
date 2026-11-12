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
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var usernameOrEmail = login.UsernameOrEmail;
                var password = login.Password;

                // Check Email
                if (usernameOrEmail.Trim().Contains('@'))
                {
                    // Fetch hashed password
                    var fetchHashedPassword = await _context.Users
                        .Where(u => u.Email == usernameOrEmail.ToLower())
                        .Select(u => u.PasswordHash)
                        .FirstOrDefaultAsync();

                    var emailExists = GetEmailForLogin(usernameOrEmail);

                    var passwordExists = BCrypt.Net.BCrypt.Verify(password, fetchHashedPassword);

                    if (emailExists == null)
                    {
                        return NotFound(new { Message = $"Email: {usernameOrEmail} does not exist or is not found" });
                    }
                    else if (!passwordExists)
                    {
                        return Unauthorized(new { Message = "Password is incorrect!" });
                    }
                    else
                    {
                        return Ok(new { Message = "Credentials exist!" });
                    }
                }
                else
                {
                    // Fetch hashed password
                    var fetchHashedPassword = await _context.Users
                        .Where(u => u.Username == usernameOrEmail.ToLower())
                        .Select(u => u.PasswordHash)
                        .FirstOrDefaultAsync();

                    var userExists = GetUserForLogin(usernameOrEmail);

                    var passwordExists = BCrypt.Net.BCrypt.Verify(password, fetchHashedPassword);

                    if (userExists == null)
                    {
                        return NotFound(new { Message = $"Username: {usernameOrEmail} does not exists or is not found" });
                    }
                    else if (!passwordExists)
                    {
                        return Unauthorized(new { Message = "Password is incorrect!" });
                    }
                    else
                    {
                        return Ok(new { Message = $"Credentials exist!\n Welcome {usernameOrEmail}!" });
                    }

                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong with the server." });
            }
        }

        private async Task<User> GetUserForLogin(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username.ToLower());

            return user;
        }

        private async Task<User> GetEmailForLogin(string email)
        {
            var userEmail = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == email.ToLower());
            
            return userEmail;
        }
    }
}
