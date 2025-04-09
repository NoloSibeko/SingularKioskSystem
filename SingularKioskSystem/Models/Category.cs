using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SingularKioskSystem.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public string CategoryName { get; set; }

        public int Description { get; set; }

        public ICollection<Products> Products { get; set; } 
    }
}