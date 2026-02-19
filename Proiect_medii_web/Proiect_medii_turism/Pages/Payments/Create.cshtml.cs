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
            if (Payment.Amount == 0 && Payment.BookingId > 0)
            {
                var booking = await _context.Bookings
                    .Include(b => b.TourPackage)
                    .FirstOrDefaultAsync(b => b.BookingId == Payment.BookingId);

                if (booking?.TourPackage != null)
                {
                    Payment.Amount = booking.TourPackage.Price * booking.NumberOfPeople;
                }
            }
            ModelState.Remove("Payment.Amount");

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
            var bookings = _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.TourPackage)
                .AsNoTracking()
                .Select(b => new
                {
                    b.BookingId,
                    ClientEmail = b.Client != null ? b.Client.Email : "Unknown Client",
                    PackageName = b.TourPackage != null ? b.TourPackage.Name : "Unknown Package",
                    b.NumberOfPeople,
                    Price = b.TourPackage != null ? b.TourPackage.Price : 0m
                })
                .ToList()
                .Select(b => new
                {
                    b.BookingId,
                    DisplayText = $"{b.ClientEmail} - {b.PackageName} ({b.NumberOfPeople} people)",
                    Amount = b.Price * b.NumberOfPeople
                })
                .ToList();

            ViewData["BookingId"] = new SelectList(bookings, "BookingId", "DisplayText");
            ViewData["BookingAmounts"] = bookings.ToDictionary(b => b.BookingId, b => b.Amount);
        }
    }
}
