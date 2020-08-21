using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            Generate generate = new Generate();
            generate.GeneratePassword(size);
        }
    }
    public class Generate
    {
        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(0, 10);
        }
        public string GenerateString()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            return builder.ToString();
        }
        public void GeneratePassword(int size)
        {
            StringBuilder builder = new StringBuilder();
            for (int a = 0; a < size; a++)
            {
                Random random = new Random();
                switch (random.Next(0, 2))
                {
                    case 0:
                        //password += GenerateNumber();
                        builder.Append(GenerateNumber());
                        break;
                    case 1:
                        //password += GenerateString();
                        builder.Append(GenerateString());
                        break;
                }
            }
            Console.WriteLine(builder);
        }
    }
}
