using BookReviews2024.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviews2024.Data
{
    public class ApplicationDbContext : DbContext
    {
        // constructor just calls the base class constructor
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // one DbSet for each domain model class
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
