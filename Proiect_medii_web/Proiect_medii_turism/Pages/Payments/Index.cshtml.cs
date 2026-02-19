using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;

namespace Proiect_medii_turism.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_medii_turism.Models.AppDbContext _context;

        public IndexModel(Proiect_medii_turism.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Payment = await _context.Payments
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Client)
                .Include(p => p.Booking)
                    .ThenInclude(b => b.TourPackage)
                .ToListAsync();
        }
    }
}
