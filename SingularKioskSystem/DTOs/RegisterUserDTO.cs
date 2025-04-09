using System.ComponentModel.DataAnnotations;
using SingularKioskSystem.Models.Enums;
using System.Text.Json.Serialization;


namespace SingularKioskSystem.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[^@\s]+@singular\.co\.za$", ErrorMessage = "Email must be @singular.co.za")]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain a digit and a special character")]
        public string Password { get; set; }

        //public string UserRole { get; set; } = "User"; // optional: only keep if you want Swagger to display it
    }


}
