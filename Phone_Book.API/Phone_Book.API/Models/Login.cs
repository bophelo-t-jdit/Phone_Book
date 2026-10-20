using System.ComponentModel.DataAnnotations;

namespace Phone_Book.API.Models
{
    public class Login
    {
        [Required]
        public string usernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
