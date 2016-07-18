using Embryo.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Tests.Services
{
    public class MockGuidGenerator : IDbGuidGenerator
    {
        public MockGuidGenerator(string guid)
        {
            _guid = guid;
        }

        string _guid;

        public string Generate() => _guid;

    }
}
