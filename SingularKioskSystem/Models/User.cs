using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SingularKioskSystem.Models.Enums;

namespace SingularKioskSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string UserRole { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PasswordHash { get; set; }

        public string AccountStatus { get; set; }

        public string Email { get; set; }

        public string ContactNumber{ get; set; }

        public Wallet Wallet { get; set; }

        public Admin Admin { get; set; }
        public Cart Carts { get; set; }

        public ICollection<TransactionDetails> Transaction { get; set; }

        public ICollection<Products> Products { get; set; }
        public AdminRole AdminID { get; internal set; }
    }
}
