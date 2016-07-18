using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Data.Services
{
    /// <summary>
    /// Generates a URL-friendly, global unique identifier for database keys
    /// </summary>
    public class Base64GuidGenerator : IDbGuidGenerator
    {
        public string Generate()
        {
            /* Source: http://madskristensen.net/post/A-shorter-and-URL-friendly-GUID */
            var newGuid = Guid.NewGuid();
            string enc = Convert.ToBase64String(newGuid.ToByteArray());
            enc = enc.Replace("/", "_");
            enc = enc.Replace("+", "-");
            return enc.Substring(0, 22);
        }
    }
}
