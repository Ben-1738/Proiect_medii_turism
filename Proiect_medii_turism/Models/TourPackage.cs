using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class TourPackage
    {
        public int TourPackageId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Destination { get; set; }
        [Range(0, 50000, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Leaving { get; set; }
        [DataType(DataType.Date)]
        public DateTime Returning { get; set; }
    }
}
