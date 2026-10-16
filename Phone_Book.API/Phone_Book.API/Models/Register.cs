using System.ComponentModel.DataAnnotations;

namespace Phone_Book.API.Models
{
    public class Register
    {
        [Required, MinLength(2)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
