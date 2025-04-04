using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingularKioskSystem.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public int Description { get; set; }

        public ICollection<Products> Products { get; set; } // One-to-Many
    }
}
