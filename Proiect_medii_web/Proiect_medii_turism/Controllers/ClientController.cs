using Microsoft.AspNetCore.Mvc;
using Proiect_medii_turism.Models;

[ApiController]
[Route("api/clients")]
public class ClientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Clients.ToList());
    }

    [HttpPost]
    public IActionResult Post(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
        return Ok(client);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Client client)
    {
        if (id != client.ClientId)
            return BadRequest();

        _context.Clients.Update(client);
        _context.SaveChanges();
        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var client = _context.Clients.Find(id);
        if (client == null)
            return NotFound();

        _context.Clients.Remove(client);
        _context.SaveChanges();
        return Ok();
    }
}
