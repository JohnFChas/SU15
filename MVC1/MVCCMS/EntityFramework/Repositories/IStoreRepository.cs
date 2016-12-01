using MVCCMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCMS.EntityFramework.Repositories
{
    public interface IStoreRepository : IDisposable
    {
        Product[] GetProducts();
        Product GetProduct(int id);
        bool CreateProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        bool DeleteProduct(int id);
    }
}
