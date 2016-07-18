using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Domain.Repositories
{
    public interface IPostRepository
    {
        Domain.Models.Post Get(string entityId);
        IList<Domain.Models.Post> GetAll();
        bool Insert(Domain.Models.Post entity);
        bool Update(Domain.Models.Post entity);
        bool Delete(string entityId);
    }
}
