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
        public void CreateProduct(Product newProduct)
        {
            using (var db = new StoreContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var db = new StoreContext())
            {
                var product = db.Products.SingleOrDefault(p => p.Id == id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            using (var db = new StoreContext())
            {
                return db.Products.SingleOrDefault(p => p.Id == id);
            }
        }

        public Product[] GetProducts()
        {
            using (var db = new StoreContext())
            {
                return db.Products.ToArray();
            }
        }

        public void UpdateProduct(Product updatedProduct)
        {
            using (var db = new StoreContext())
            {
                db.Products.Attach(updatedProduct);
                var entry = db.Entry(updatedProduct);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}