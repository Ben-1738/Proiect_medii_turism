using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;

namespace Proiect_medii_turism.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_medii_turism.Models.AppDbContext _context;

        public DetailsModel(Proiect_medii_turism.Models.AppDbContext context)
        {
            _context = context;
        }

        public Agent Agent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FirstOrDefaultAsync(m => m.AgentId == id);
            if (agent == null)
            {
                return NotFound();
            }
            else
            {
                Agent = agent;
            }
            return Page();
        }
    }
}
