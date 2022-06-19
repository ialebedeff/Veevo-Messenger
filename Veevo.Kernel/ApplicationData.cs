using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel
{
    internal class ApplicationData
    {
        public static class Constsants
        {
            public const string UserAgent = "VeevoAPI";
            public const string ServerBaseAddress = "https://localhost:7218";
            public const string ApplicationName = "Veevo";
            public const string DictionaryData = "Data";
            public const string TokenPath = $"{DictionaryData}/Token.json";
        }
    }
}
