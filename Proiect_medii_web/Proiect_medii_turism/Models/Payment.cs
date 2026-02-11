using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_medii_turism.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; } = "Cash";
        [Required]
        public string Status { get; set; } = "Pending";
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
