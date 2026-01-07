using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is mandatory.")]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }

        public Admin? Admin { get; set; }
        public Client? Client { get; set; }
    }
}
