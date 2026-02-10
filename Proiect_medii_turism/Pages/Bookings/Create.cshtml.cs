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
            var packageList = _context.TourPackages.Select(x => new
            {
                x.PackageId,
                PackageFullName = x.Name + " - " + x.Destination
            });
            ViewData["PackageId"] = new SelectList(packageList, "PackageId", "PackageFullName");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
