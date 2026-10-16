namespace Phone_Book.API.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string CellNumber { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
