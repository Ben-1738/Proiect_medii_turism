using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
