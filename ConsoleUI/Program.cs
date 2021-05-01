using System;
using PasswordGeneratorLibrary;

namespace ConsoleUI
{
    class Program
    {
        private static GeneratorSettings Settings { get; set; }
        private static ConsoleKeyInfo ConsoleKeyInfo { get; set; }
        private static bool IsDone { get; set; }
        static void Main(string[] args)
        {
            do
            {
                GeneratorAdjustment();
                GeneratePassword();
            } while (!IsDone);
        }
        private static void GeneratorAdjustment()
        {
            Settings = new GeneratorSettings();

            string userInput = "";

            Settings.PasswordLength = GetPasswordLength(userInput);
            do
            {
                Settings.IncludeLowercase = IsCharSetAllowed(userInput, "Lowercase");

                Settings.IncludeUppercase = IsCharSetAllowed(userInput, "Uppercase");

                Settings.IncludeNumbers = IsCharSetAllowed(userInput, "Numbers");

                Settings.IncludeSymbols = IsCharSetAllowed(userInput, "Symbols");

                if (!Settings.IncludeLowercase && !Settings.IncludeUppercase && !Settings.IncludeNumbers && !Settings.IncludeSymbols)
                {
                    Console.WriteLine($"Select at least one character type.");
                    Console.WriteLine();
                }
            } while (!Settings.IncludeLowercase && !Settings.IncludeUppercase && !Settings.IncludeNumbers && !Settings.IncludeSymbols);
        }
        private static void GeneratePassword()
        {
            do
            {
                Console.WriteLine(PasswordGenerator.Generate(Settings));
                Console.WriteLine();
                Console.WriteLine($"Press ENTER to REGENERATE.");
                Console.WriteLine($"Press BACKSPACE to RESTART.");
                Console.WriteLine();
                ConsoleKeyInfo = Console.ReadKey();
                if (ConsoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    continue;
                }
                else if (ConsoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    IsDone = false;
                    break;
                }
                else
                {
                    IsDone = true;
                    break;
                }
            } while (true);
        }
        private static int GetPasswordLength(string userInput)
        {
            do
            {
                Console.Write($"Password Length (8-256): ");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out int output);
                Console.WriteLine();
                if (7 < output && output < 257)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine($"{ userInput } is invalid.");
                    Console.WriteLine();
                }
            } while (true);
        }
        private static bool IsCharSetAllowed(string userInput, string charSet)
        {
            do
            {
                Console.Write($"Include { charSet } (yes/no): ");
                userInput = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (userInput == "yes" || userInput == "no")
                {
                    return (userInput == "yes") ? true : false;
                }
                else
                {
                    Console.WriteLine($"{ userInput } is invalid.");
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
