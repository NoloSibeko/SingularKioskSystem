using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SingularKioskSystem.Models.Enums;

namespace SingularKioskSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public string UserRole { get; set; }

        public User User { get; set; }

        public AdminRole AdminRole { get; set; }
    }
}
