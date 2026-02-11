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

        public string ? FullName => $"{FirstName} {LastName}";
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
