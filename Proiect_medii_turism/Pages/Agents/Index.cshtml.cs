using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_turism.Models;
using Microsoft.AspNetCore.Authorization;

namespace Proiect_medii_turism.Pages.Agents
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_medii_turism.Models.AppDbContext _context;

        public IndexModel(Proiect_medii_turism.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Agent> Agent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Agent = await _context.Agents.ToListAsync();
        }
    }
}
