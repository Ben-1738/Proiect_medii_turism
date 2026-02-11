using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;

namespace Proiect_medii_turism.Pages.Payments
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
            LoadBookingsDropdown();
            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadBookingsDropdown();
                return Page();
            }

            _context.Payments.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void LoadBookingsDropdown()
        {
            var bookingsData = _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.TourPackage)
                .AsNoTracking()
                .ToList();

            var bookings = bookingsData
                .Where(b => b.Client != null && b.TourPackage != null)
                .Select(b => new
                {
                    b.BookingId,
                    DisplayText = $"{b.Client!.Email} - {b.TourPackage!.Name} ({b.NumberOfPeople} people)",
                    Amount = b.TourPackage.Price * b.NumberOfPeople
                })
                .ToList();

            ViewData["BookingId"] = new SelectList(bookings, "BookingId", "DisplayText");
            ViewData["BookingAmounts"] = bookings.ToDictionary(b => b.BookingId, b => b.Amount);
        }
    }
}
