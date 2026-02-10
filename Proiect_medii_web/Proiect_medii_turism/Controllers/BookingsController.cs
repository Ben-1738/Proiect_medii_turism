using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }
 

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Bookings
            .Include(b => b.Client)
            .Include(b => b.TourPackage)
            .ToList());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        booking.BookingId = 0;
        booking.RezervationDate = DateTime.Now;
        booking.Status = "Noua";

        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return Ok(booking);
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Booking booking)
    {
        if (id != booking.BookingId)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Bookings.Update(booking);
        _context.SaveChanges();
        return Ok(booking);
    }

  
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null)
            return NotFound();

        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return Ok();
    }
}
