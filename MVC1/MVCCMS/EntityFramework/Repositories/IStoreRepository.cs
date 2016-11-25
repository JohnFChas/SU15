using MVCCMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCMS.EntityFramework.Repositories
{
    interface IStoreRepository
    {
        Product[] GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int id);
    }
}
