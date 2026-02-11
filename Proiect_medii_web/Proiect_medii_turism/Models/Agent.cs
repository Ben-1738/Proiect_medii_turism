using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

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

        public ICollection<TourPackage> TourPackages { get; set; } = new HashSet<TourPackage>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
