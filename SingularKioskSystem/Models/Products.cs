using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingularKioskSystem.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public decimal Price { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public Boolean isAvailable { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public User User { get; set; } // Navigation property

        public ICollection<Cart> Carts { get; set; }
    }
}
