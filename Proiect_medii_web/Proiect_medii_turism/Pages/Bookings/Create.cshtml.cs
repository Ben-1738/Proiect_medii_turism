using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_medii_turism.Models;

namespace Proiect_medii_turism.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_medii_turism.Models.AppDbContext _context;

        public CreateModel(Proiect_medii_turism.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
            ViewData["PackageId"] = new SelectList(_context.TourPackages, "PackageId", "Name");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
                ViewData["PackageId"] = new SelectList(_context.TourPackages, "PackageId", "Name");
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
