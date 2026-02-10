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
<<<<<<< HEAD
        public DbSet<Agent> Agents { get; set; }
<<<<<<< Updated upstream:Proiect_medii_turism/Models/AppDbContext.cs
<<<<<<< Updated upstream:Proiect_medii_turism/Models/AppDbContext.cs
=======
>>>>>>> parent of 16978ae (In mare parte e gata, de infrumusetaree mai are nevoie.)
=======
>>>>>>> Stashed changes:Proiect_medii_web/Proiect_medii_turism/Models/AppDbContext.cs
=======
>>>>>>> Stashed changes:Proiect_medii_web/Proiect_medii_turism/Models/AppDbContext.cs
    }
}