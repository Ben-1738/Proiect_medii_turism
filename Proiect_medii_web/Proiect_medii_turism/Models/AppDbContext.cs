using Microsoft.EntityFrameworkCore;

namespace Proiect_medii_turism.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}