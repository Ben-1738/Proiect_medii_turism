using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_medii_turism.Models;
using System.ComponentModel.DataAnnotations;

namespace Proiect_medii_turism.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Username is mandatory.")]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is mandatory")]
            [DataType(DataType.Password)]
            [StringLength(100, MinimumLength = 4, ErrorMessage = "Password must be atleast 4 caracters.")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Password don't match!")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string Role { get; set; } 
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == Input.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "This username already exists.");
                return Page();
            }


            var user = new User
            {
                Username = Input.Username,
                PasswordHash = Input.Password,
                Role = Input.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            return RedirectToPage("/Login");
        }
    }
}