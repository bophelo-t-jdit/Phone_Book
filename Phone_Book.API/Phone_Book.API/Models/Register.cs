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
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?=.*\d).+$", 
            ErrorMessage = "Your password must have at least one capital letter, one special letter and one number.")] // Uppercase, Special Characters, Numbers
        public string Password { get; set; }
    }
}
