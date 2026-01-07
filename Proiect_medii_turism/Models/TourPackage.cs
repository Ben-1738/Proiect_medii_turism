using System.ComponentModel.DataAnnotations;
namespace Proiect_medii_turism.Models

{
    public class TourPackage
    {
        [Key]
        public int PackageId { get; set; }
        [Required(ErrorMessage = "Package name is required.")]
        public string Name { get; set; }
        [Required]
        public string Destination { get; set; }
        [Range(1,1000000)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
