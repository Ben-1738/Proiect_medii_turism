using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Proiect_medii_turism.Data
{
    public class TourismIdentityContext : IdentityDbContext
    {
        public TourismIdentityContext(DbContextOptions<TourismIdentityContext> options)
            : base(options) { }
    }
}
