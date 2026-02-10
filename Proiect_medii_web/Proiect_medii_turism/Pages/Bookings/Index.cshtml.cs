using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;


namespace Proiect_medii_turism.Pages.Bookings
{
    [Authorize(Roles = "Admin, Clients")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_medii_turism.Models.AppDbContext _context;

        public IndexModel(Proiect_medii_turism.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null) {
                Booking = await _context.Bookings
                    .Include(b => b.Client)
                    .Include(b => b.TourPackage)
                    .ToListAsync();
            }
        }
    }
}
