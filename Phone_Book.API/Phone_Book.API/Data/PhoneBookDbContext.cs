using Microsoft.EntityFrameworkCore;
using Phone_Book.API.Models;

namespace Phone_Book.API.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
