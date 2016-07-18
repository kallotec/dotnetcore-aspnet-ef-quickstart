using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Tests.Services
{
    public abstract class InMemoryKeyedRepositoryBase<TEntity, TKey>
    {
        public InMemoryKeyedRepositoryBase(Func<TEntity, TKey, bool> keyComparer)
        {
            _keyComparer = keyComparer;
        }

        Func<TEntity, TKey, bool> _keyComparer;
        public List<TEntity> Items = new List<TEntity>();


        public bool Delete(TKey id)
        {
            var post = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (post == null)
                return false;

            return Items.Remove(post);
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
            var post = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (post != null)
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
            var post = Items.FirstOrDefault(p => _keyComparer(p, id));
            if (post == null)
                return false;

            // Replace old version with new
            Items.Remove(post);
            Items.Add(post);

            return true;
        }

    }
}
