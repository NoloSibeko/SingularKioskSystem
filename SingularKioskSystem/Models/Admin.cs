using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SingularKioskSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string AdminName { get; set; }

        [Required, MaxLength(100)]
        public string AdminSurname { get; set; }

        [Required]
        public string Role { get; set; }

        public User User { get; set; } // Navigation property
    }
}
