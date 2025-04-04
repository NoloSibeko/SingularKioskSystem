using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingularKioskSystem.Models
{
    public class Wallet
    {
        [Key]
        public int WalletID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public User User { get; set; }
        public ICollection<TransactionDetails> TransactionDetails { get; set; }
    }
}
