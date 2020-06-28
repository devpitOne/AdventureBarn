using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBarn.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository, IDisposable
    {
        private AdventureBarnContext context;

        public ProductRepository(AdventureBarnContext context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            Save();
        }

        public void Delete(long productID)
        {
            Product product = context.Products.Find(productID);
            context.Products.Remove(product);
            Save();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetByID(long ProductId)
        {
            return context.Products.Find(ProductId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
