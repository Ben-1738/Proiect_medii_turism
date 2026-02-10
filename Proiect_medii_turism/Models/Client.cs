using System.ComponentModel.DataAnnotations;
namespace Proiect_medii_turism.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Full name")]
        public string? FullName
        {
            get {return FirstName + " " + LastName; }
        }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
