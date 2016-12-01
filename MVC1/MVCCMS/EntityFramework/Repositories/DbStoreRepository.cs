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

        public bool CreateProduct(Product newProduct)
        {
            var product = db.Products.Add(newProduct);

            if (product != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProduct(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            var removedProduct = db.Products.Remove(product);

            if (removedProduct != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public Product GetProduct(int id)
        {
            return db.Products.SingleOrDefault(p => p.Id == id);
        }

        public Product[] GetProducts()
        {
            return db.Products.Include(p => p.Categories).ToArray();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            db.Products.Attach(updatedProduct);
            var entry = db.Entry(updatedProduct);
            entry.State = EntityState.Modified;
            db.SaveChanges();
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