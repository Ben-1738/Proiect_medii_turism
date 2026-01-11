using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Proiect_medii.Models;

namespace Proiect_medii.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        [Required]
        public int PackageId { get; set; }
        public TourPackage? TourPackage { get; set; }
        [DataType(DataType.Date)]
        public DateTime RezervationDate { get; set; }
        [Range(1, 20)]
        public int NumberOfPeople { get; set; }
        public string Status { get; set; } 

        public string? Observations { get; set; }
    }
}
