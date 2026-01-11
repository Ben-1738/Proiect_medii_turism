using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;

namespace Proiect_medii_turism.Pages
{
    [Authorize] // Doar daca esti logat vezi dashboard-ul
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public int TotalPackages { get; set; }
        public int TotalClients { get; set; }
        public int NewBookings { get; set; }

        public async Task OnGetAsync()
        {
            TotalPackages = await _context.TourPackages.CountAsync();
            TotalClients = await _context.Clients.CountAsync();
            NewBookings = await _context.Bookings.Where(b => b.Status == "Pending").CountAsync();
        }
    }
}
