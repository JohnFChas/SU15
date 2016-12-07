namespace MVCCMS.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCCMS.EntityFramework.Contexts.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCCMS.EntityFramework.Contexts.StoreContext context)
        {
            // Create categories, products and an order
            Category cat1 = new Category { Id = 1, Name = "Category 1" },
                     cat2 = new Category { Id = 2, Name = "Category 2" };

            Product prod1 = new Product { Id = 1, Name = "Product 1", Price = 100, CategoryId = 1 },
                    prod2 = new Product { Id = 2, Name = "Product 2", Price = 100, CategoryId = 2 },
                    prod3 = new Product { Id = 3, Name = "Product 3", Price = 100, CategoryId = 2 };

            Order order = new Order { Id = 1 };

            // Add products to categories and order
            cat1.Products.AddRange(new Product[] { prod1, prod2 });
            cat2.Products.Add(prod3);

            order.Products.AddRange(new Product[] { prod1, prod3 });

            var categories = new Category[] { cat1, cat2 };
            var products = new Product[] { prod1, prod2, prod3 };

            // Since we add all products to categories we dont need to add them a second time to
            // context.Products.
            context.Categories.AddOrUpdate(categories);
            context.Products.AddOrUpdate(products);
            context.Orders.AddOrUpdate(order);
        }
    }
}
