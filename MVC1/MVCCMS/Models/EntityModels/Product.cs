using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCMS.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Order> Orders { get; set; }

        public Product()
        {
            Orders = new List<Order>();
        }
    }
}