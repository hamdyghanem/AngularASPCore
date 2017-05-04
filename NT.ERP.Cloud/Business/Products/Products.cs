using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NTERPCloud.Models;

namespace NTERPCloud.Business.Products
{
    public class Products : IProducts
    {
        private readonly ConcurrentDictionary<int, Product> _storage = new ConcurrentDictionary<int, Product>();

        public Product  GetSingle(int id)
        {
            Product product;
            return _storage.TryGetValue(id, out product) ? product : null;
        }

        public Product Add(Product item)
        {
            item.Id = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;

            if (_storage.TryAdd(item.Id, item))
            {
                return item;
            }

            throw new Exception("Item could not be added");
        }

        public void Delete(int id)
        {
            Product product;
            if (!_storage.TryRemove(id, out product))
            {
                throw new Exception("Item could not be removed");
            }
        }

        public Product Update(int id, Product item)
        {
            _storage.TryUpdate(id, item, GetSingle(id));
            return item;
        }

        public ICollection<Product> GetAll()
        {
            return _storage.Values;
        }

        public int Count()
        {
            return _storage.Count;
        }
    }
}