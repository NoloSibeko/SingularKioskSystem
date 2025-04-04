using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SingularKioskSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [ForeignKey("Admin")]
        public int AdminID { get; set; }

        [ForeignKey("Wallet")]
        public int WalletID { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string AccountStatus { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ContactNumber{ get; set; }

        // One-to-One: User has one Wallet
        public Wallet Wallet { get; set; }

        // One-to-One: A User can be an Admin
        public Admin Admin { get; set; }
        public Cart Carts { get; set; }

        // One-to-Many: A User can have multiple Transactions
        public ICollection<TransactionDetails> Transaction { get; set; }

        // One-to-Many: A User can own multiple Products
        public ICollection<Products> Products { get; set; }
    }
}
