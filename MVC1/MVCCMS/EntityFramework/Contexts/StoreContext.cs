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
        // Default constructor which sends the name of the connection string
        // for the database we want to use to the base constructor.
        public StoreContext()
            : base("MyDatabase")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}