using NameGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NameGenerator.GeneratorBase;

namespace Veevo.BLL.BusinessModels
{
    internal class UsernameGenerator
    {
        private GamerTagGenerator _gamerTagGenerator;
        public UsernameGenerator() => _gamerTagGenerator = new GamerTagGenerator() { SpaceCharacter = "_", Sex = SexTypes.Unisex };
        public string GenerateUsername() => _gamerTagGenerator.Generate();
    }
}
