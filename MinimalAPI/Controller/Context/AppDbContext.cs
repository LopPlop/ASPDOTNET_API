using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Models;

namespace MinimalAPI.Controller.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels => Set<Hotel>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
