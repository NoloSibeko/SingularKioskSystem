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

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public decimal Price { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Boolean isAvailable { get; set; }

        public Category Category { get; set; }
        public User User { get; set; } 

        public ICollection<Cart> Carts { get; set; }
    }
}
