using AdventureBarn.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AdventureBarn.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AdventureBarnContext _context;
        private DbSet<T> _table = null;
        private bool _disposed = false;

        public GenericRepository(AdventureBarnContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Create(T obj)
        {
            _table.Add(obj);
            Save();
        }

        public void Delete(long id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(long id)
        {
            return _table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
    }
}
