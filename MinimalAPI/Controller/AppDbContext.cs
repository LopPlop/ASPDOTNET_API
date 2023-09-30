using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Controller
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels => Set<Hotel>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
