using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Required]
        public int PackageId { get; set; }
        public TourPackage? TourPackage { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
