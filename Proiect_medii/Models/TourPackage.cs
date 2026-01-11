using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_medii.Models;

namespace Proiect_medii.Models
{
    public class TourPackage : IValidatableObject
    {
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Package name is required.")]
        public string Name { get; set; }

        [Required]
        public string Destination { get; set; }

        [Range(1, 1_000_000)]
        public decimal Price { get; set; }

        public DateTime LeavingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReturnDate < LeavingDate)
            {
                yield return new ValidationResult(
                    "Date of return cannot be before date of departure!",
                    new[] { nameof(ReturnDate) });
            }

            if (LeavingDate < DateTime.Now.Date)
            {
                yield return new ValidationResult(
                    "Date of departure cannot be in the past!",
                    new[] { nameof(LeavingDate) });
            }
        }

    }
}
