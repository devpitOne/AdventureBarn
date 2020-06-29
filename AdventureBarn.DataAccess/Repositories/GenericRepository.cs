using AdventureBarn.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

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

        /// <summary>
        /// The update method uses a very simple form of handling for related entities
        /// A more full response would involve an external framework for graph walking
        /// </summary>
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        #region Private Methods
        private bool Exists(string entityName)
        {
            ObjectContext objContext = ((IObjectContextAdapter)_context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
            return workspace.GetItems<EntityType>(DataSpace.CSpace).Any(e => e.Name == entityName);
        }

        private void Attach<RelatedEntity>(RelatedEntity relatedEntity) where RelatedEntity : class
        {
            _context.Set<RelatedEntity>().Attach(relatedEntity);
        } 

        #endregion
    }
}
