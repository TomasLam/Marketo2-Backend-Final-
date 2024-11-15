using System.ComponentModel.DataAnnotations;

namespace MarketoTest2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
         public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
         [EmailAddress(ErrorMessage = "Invalid email address.")]
          public string Email { get; set; } = string.Empty;

         [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 6)]
             public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
         [Required(ErrorMessage = "Please confirm your password.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Street name is required.")]
        public string StreetName { get; set; } = string.Empty;

         [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        public string? Mobile { get; set; }

        public string? Company { get; set; }

         [Required(ErrorMessage = "You must accept the terms and conditions.")]
        public bool Terms { get; set; }
    }
}
