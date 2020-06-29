using System;
using System.Collections.Generic;

namespace AdventureBarn.Contracts.Repositories
{
    /// <summary>
    /// A generic repository providing CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(long Id);
        void Create(T obj);
        void Delete(long Id);
        void Update(T obj);
        void Save();
    }
}