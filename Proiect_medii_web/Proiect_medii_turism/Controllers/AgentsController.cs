using Microsoft.AspNetCore.Mvc;
using Proiect_medii_turism.Models;

[ApiController]
[Route("api/agents")]
public class AgentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AgentsController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Agents.ToList());
    }

  
    [HttpPost]
    public IActionResult Post(Agent agent)
    {
        _context.Agents.Add(agent);
        _context.SaveChanges();
        return Ok(agent);
    }
}
