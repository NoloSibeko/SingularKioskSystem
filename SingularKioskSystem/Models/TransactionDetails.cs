using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace SingularKioskSystem.Models
{
    public class TransactionDetails
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Wallet")]
        public int WalletID { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public User User { get; set; } // Navigation property

        public Wallet Wallet { get; set; } // Navigation property

        public Cart Cart { get; set; }


    }
}
