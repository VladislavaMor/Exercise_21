using Exercise_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_21.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; } = default!;
    }
}
