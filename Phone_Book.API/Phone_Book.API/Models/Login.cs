using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Phone_Book.API.Models
{
    public class Login
    {
        [Required]
        [JsonPropertyName("UsernameOrEmail")]
        public string UsernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
