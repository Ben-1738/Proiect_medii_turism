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
<<<<<<< HEAD

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Verificăm dacă data de întoarcere este înaintea plecării
            if (ReturnDate < LeavingDate)
            {
                yield return new ValidationResult(
                    "Date of return cannot be before date of departure!",
                    new[] { nameof(ReturnDate) });
            }

            // Opțional: Validare să nu fie în trecut
            if (LeavingDate < DateTime.Now.Date)
            {
                yield return new ValidationResult(
                    "Date of departure cannot be in the past!",
                    new[] { nameof(LeavingDate) });
            }
        }
=======
>>>>>>> parent of 16978ae (In mare parte e gata, de infrumusetaree mai are nevoie.)
    }
}
