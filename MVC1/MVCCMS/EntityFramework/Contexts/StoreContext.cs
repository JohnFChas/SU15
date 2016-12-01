using MVCCMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCMS.EntityFramework.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("MyDatabase")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}