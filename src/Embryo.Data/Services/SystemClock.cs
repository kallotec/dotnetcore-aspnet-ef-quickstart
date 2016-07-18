using Embryo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Data.Services
{
    public class SystemClock : IClock
    {
        public DateTime GetTime() => DateTime.UtcNow;
    }
}
