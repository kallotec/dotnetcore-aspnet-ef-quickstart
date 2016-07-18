using Embryo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Tests.Services
{
    public class MockClock : IClock
    {
        public MockClock(DateTime mockedTime)
        {
            _mockedTime = mockedTime;
        }

        DateTime _mockedTime;

        public DateTime GetTime() => _mockedTime;

    }
}
