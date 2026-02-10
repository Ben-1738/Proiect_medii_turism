using System.ComponentModel.DataAnnotations;
namespace Proiect_medii_turism.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } // "Admin" sau "Agent"
    }
}
