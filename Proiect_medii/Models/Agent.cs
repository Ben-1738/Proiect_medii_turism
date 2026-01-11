using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Proiect_medii.Models;

namespace Proiect_medii.Models
{
    public class Agent
    {
    
        public int AgentId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? Telefon { get; set; }
    }
}
