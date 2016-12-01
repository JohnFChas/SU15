using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCMS.Models.EntityModels;

namespace MVCCMS.EntityFramework.Repositories
{
    public class TestStoreRepository : IStoreRepository
    {
        List<Product> products;

        public TestStoreRepository()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100 },
                new Product { Id = 2, Name = "Product 2", Price = 100 },
                new Product { Id = 3, Name = "Product 3", Price = 100 },
                new Product { Id = 4, Name = "Product 4", Price = 100 }
            };
        }

        public bool CreateProduct(Product newProduct)
        {
            products.Add(newProduct);

            return true;
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product[] GetProducts()
        {
            return products.ToArray();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            throw new NotImplementedException();
        }
    }
}