using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCMS.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public virtual List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}