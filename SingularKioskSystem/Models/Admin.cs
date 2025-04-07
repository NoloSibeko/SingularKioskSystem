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

        public string AdminName { get; set; }

        public string AdminSurname { get; set; }

        public string Role { get; set; }

        public User User { get; set; } // Navigation property
    }
}
