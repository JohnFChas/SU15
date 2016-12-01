using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCMS.Models.EntityModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}