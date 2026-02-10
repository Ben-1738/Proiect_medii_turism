using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Proiect_medii_turism.Data
{
    public class LibraryIdentityContext : IdentityDbContext
    {
        public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
            : base(options) { }
    }
}
