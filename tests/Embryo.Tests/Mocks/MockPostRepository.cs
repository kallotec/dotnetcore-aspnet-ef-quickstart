using Embryo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Embryo.Domain.Models;
using Embryo.Tests.Services;

namespace Embryo.Tests.Mocks
{
    public class MockPostRepository : InMemoryKeyedRepositoryBase<Post, string>, IPostRepository
    {
        public MockPostRepository() : base(keyComparer: (post, key) => string.Equals(post.Id, key, StringComparison.Ordinal))
        {
        }

        public bool Delete(string entityId) => base.Delete(entityId);

        public Post Get(string entityId) => base.Get(entityId);

        public IList<Post> GetAll() => base.GetAll();

        public bool Insert(Post entity) => base.Insert(entity, entity.Id);

        public bool Update(Post entity) => base.Update(entity, entity.Id);

    }
}
