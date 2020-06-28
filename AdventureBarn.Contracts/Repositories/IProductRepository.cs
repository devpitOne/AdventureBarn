using AdventureBarn.Contracts.Models;
using System;
using System.Collections.Generic;

namespace AdventureBarn.Contracts.Repositories
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetAll();
        Product GetByID(long ProductId);
        void Create(Product Product);
        void Delete(long ProductID);
        void Update(Product product);
        void Save();
    }
}