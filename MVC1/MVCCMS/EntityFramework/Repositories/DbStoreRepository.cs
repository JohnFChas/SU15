using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCMS.Models.EntityModels;
using MVCCMS.EntityFramework.Contexts;
using System.Data.Entity;

namespace MVCCMS.EntityFramework.Repositories
{
    public class DbStoreRepository : IStoreRepository, IDisposable
    {
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
            return db.Products.Include(p => p.Categories).ToArray();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            db.Products.Attach(updatedProduct);
            var entry = db.Entry(updatedProduct);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}