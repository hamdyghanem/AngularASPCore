using System.Collections.Generic;
using NTERPCloud.Models;

namespace NTERPCloud.Business.Products
{
    public interface IProducts
    {
        Product GetSingle(int id);
        Product Add(Product item);
        void Delete(int id);
        Product Update(int id, Product item);
        ICollection<Product> GetAll();
        int Count();
    }
}
