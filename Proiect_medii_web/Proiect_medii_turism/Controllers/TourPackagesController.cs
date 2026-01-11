using Microsoft.AspNetCore.Mvc;
using Proiect_medii_turism.Models;

[ApiController]
[Route("api/tourpackages")]
public class TourPackagesController : ControllerBase
{
    private readonly AppDbContext _context;

    public TourPackagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.TourPackages.ToList());
    }

    [HttpPost]
    public IActionResult Post(TourPackage package)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.TourPackages.Add(package);
        _context.SaveChanges();
        return Ok(package);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, TourPackage package)
    {
        if (id != package.PackageId)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.TourPackages.Update(package);
        _context.SaveChanges();
        return Ok(package);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var package = _context.TourPackages.Find(id);
        if (package == null)
            return NotFound();

        _context.TourPackages.Remove(package);
        _context.SaveChanges();
        return Ok();
    }
}
