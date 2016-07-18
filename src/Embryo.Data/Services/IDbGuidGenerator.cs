using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Data.Services
{
    public interface IDbGuidGenerator
    {
        string Generate();
    }
}
