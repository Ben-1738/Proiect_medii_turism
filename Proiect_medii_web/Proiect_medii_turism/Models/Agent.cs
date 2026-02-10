using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        public int? UserId { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Prenume { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string? Telefon { get; set; }
    }
}
