using System.ComponentModel.DataAnnotations;
namespace Proiect_medii_turism.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        [Required]
        public int PackageId { get; set; }
        public TourPackage? TourPackage { get; set; }
        [DataType(DataType.Date)]
        public DateTime RezervationDate { get; set; }
        [Range(1,20)]
        public int NumberOfPeople { get; set; }
        public string Status { get; set; } // e.g., "Confirmed", "Cancelled", "Pending"

        public string? Observations { get; set; }
    }
}
