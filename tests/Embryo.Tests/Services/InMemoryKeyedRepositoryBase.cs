using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Tests.Services
{
    public abstract class InMemoryKeyedRepositoryBase<TEntity, TKey> where TEntity : class
    {
        public InMemoryKeyedRepositoryBase(Func<TEntity, TKey, bool> keyComparer)
        {
            _keyComparer = keyComparer;
        }

        Func<TEntity, TKey, bool> _keyComparer;
        public List<TEntity> Items = new List<TEntity>();


        public bool Delete(TKey id)
        {
            var existing = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (existing == null)
                return false;

            return Items.Remove(existing);
        }

        public TEntity Get(TKey id)
        {
            return Items.FirstOrDefault(p => _keyComparer(p, id));
        }

        public IList<TEntity> GetAll()
        {
            return Items.ToList();
        }

        public bool Insert(TEntity entity, TKey id)
        {
            if (entity == null)
                return false;

            // Enforce unique keys
            var existing = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (existing != null)
                return false;

            Items.Add(entity);
            return true;
        }

        public bool Update(TEntity entity, TKey id)
        {
            if (entity == null)
                return false;

            if (Items.Contains(entity))
                return true;

            // Ensure item already exists
            var existing = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (existing == null)
                return false;

            // Replace old version with new
            Items.Remove(existing);
            Items.Add(entity);

            return true;
        }

    }
}
