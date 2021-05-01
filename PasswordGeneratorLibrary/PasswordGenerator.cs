using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorLibrary
{
    public class PasswordGenerator
    {
        public static string Generate(GeneratorSettings settings)
        {
            List<string> charSets = GeneratorProcessor.CharSetsList(settings);

            StringBuilder password = GeneratorProcessor.GetPassword(settings, charSets);

            return password.ToString();
        }
    }
}
