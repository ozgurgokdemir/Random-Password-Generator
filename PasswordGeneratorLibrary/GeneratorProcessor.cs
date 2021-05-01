using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorLibrary
{
    class GeneratorProcessor
    {
        internal static List<string> CharSetsList(GeneratorSettings settings)
        {
            List<string> output = new List<string>();
            if (settings.IncludeLowercase)
            {
                output.Add(CharSets.Lowercase);
            }
            if (settings.IncludeUppercase)
            {
                output.Add(CharSets.Uppercase);
            }
            if (settings.IncludeNumbers)
            {
                output.Add(CharSets.Numbers);
            }
            if (settings.IncludeSymbols)
            {
                output.Add(CharSets.Symbols);
            }
            return output;
        }
        internal static StringBuilder GetPassword(GeneratorSettings settings, List<string> charSets)
        {
            StringBuilder output = new StringBuilder();

            char randomChar;

            for (int i = 0; i < settings.PasswordLength; i++)
            {
                if (output.Length < 2)
                {
                    randomChar = GetRandomChar(charSets);
                    output.Append(randomChar);
                }
                else
                {
                    do
                    {
                        randomChar = GetRandomChar(charSets);
                    } while ((output[i - 2] == output[i - 1]) && (output[i - 1] == randomChar));
                    output.Append(randomChar);
                }
            }
            return output;
        }
        private static char GetRandomChar(List<string> charSets)
        {
            Random random = new Random();
            string randomCharSet = charSets[random.Next(charSets.Count)];
            return randomCharSet[random.Next(randomCharSet.Length)];
        }
    }
}
