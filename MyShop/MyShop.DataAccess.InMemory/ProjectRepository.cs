using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    class ProjectRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache("products") as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            Product.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            } else
            {
                throw new Exception("Product not found");
            }
        }

        public void Find(string Id)
        {
            Product productToFind = products.Find(p => p.Id == product.Id);

            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection() {
        return products.AsQueryable();
        }

         public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == product.Id);

            if (productToDelete != null)
            {
                product.Remove(productToDelete);
            } else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
