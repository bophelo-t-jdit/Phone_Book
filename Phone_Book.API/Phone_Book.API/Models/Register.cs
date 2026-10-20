using System.ComponentModel.DataAnnotations;

namespace Phone_Book.API.Models
{
    public class Register
    {
        [Required, MinLength(3, ErrorMessage = "Username must be at least 3 characters long."), MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long."), MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }
    }
}
