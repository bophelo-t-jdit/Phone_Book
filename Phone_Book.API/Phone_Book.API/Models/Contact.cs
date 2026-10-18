using System.ComponentModel.DataAnnotations;

namespace Phone_Book.API.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstNames { get; set; }

        [MaxLength(50)]
        public string? LastNames { get; set; }

        [Required]
        [MaxLength(30)]
        public string CellNumber { get; set; }

        [MaxLength(30)]
        public string? TelephoneNumber { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
