using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace SingularKioskSystem.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }

        [ForeignKey("Wallet")]
        public int WalletID { get; set; }

        [Required]
        public int NumberOfItems { get; set; }

        [Required]
        public decimal TotalAmount  { get; set; }

        public User User { get; set; }

       
        public TransactionDetails Transaction { get; set; } // Corrected property name

        public ICollection<Products> Products { get; set; }

    }
}
