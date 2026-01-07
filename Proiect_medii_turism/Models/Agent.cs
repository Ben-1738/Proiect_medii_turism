using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class Agent
    {
        [Key]
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
