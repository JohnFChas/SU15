using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCMS.Models.EntityModels;
using MVCCMS.EntityFramework.Contexts;
using System.Data.Entity;

namespace MVCCMS.EntityFramework.Repositories
{
    public class DbStoreRepository : IStoreRepository
    {
        // The DbContext is instantiated as a local variable
        StoreContext db = new StoreContext();

        public void CreateProduct(Product newProduct)
        {
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return db.Products.SingleOrDefault(p => p.Id == id);
        }

        public Product[] GetProducts()
        {
            return db.Products.Include(p => p.Category).ToArray();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            db.Products.Attach(updatedProduct);
            var entry = db.Entry(updatedProduct);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }



        public Category[] GetCategories()
        {
            return db.Categories.ToArray();
        }

        // IStoreRepository implements IDisposable (and so must all classes implementing it).
        // This gives us control over when to dispose (or close) the database connection.
        // Effectively we now have the ability to ensure that no connection is closed
        // pre-maturely before we've gathered all the data the client requested.
        // See ProductsController for more.
        public void Dispose()
        {
            db.Dispose();
        }
    }
}