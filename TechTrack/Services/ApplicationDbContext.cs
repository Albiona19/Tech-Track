using Microsoft.EntityFrameworkCore;
using TechTrack.Models;

namespace TechTrack.Services
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 

        }
        public DbSet<Product> Products { get; set; }
    }
}
