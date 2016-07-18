using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Domain.Services
{
    public interface IClock
    {
        DateTime GetTime();
    }
}
