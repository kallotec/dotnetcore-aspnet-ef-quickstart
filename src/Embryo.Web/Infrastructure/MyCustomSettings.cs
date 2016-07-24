using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Web.Infrastructure
{
    /// <summary>
    /// Maps to the "MyCustomSettings" section in appsettings.json
    /// </summary>
    public class MyCustomSettings
    {
        public string OptionA { get; set; }
        public string OptionB { get; set; }
    }
}
