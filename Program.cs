using System;
using System.IO;
using System.Text;

namespace TitleSpoofer
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] exeFiles = Directory.GetFiles(directoryPath, "*.exe");

            Random random = new Random();
            foreach (string exeFile in exeFiles)
            {
                if (Path.GetFileName(exeFile).Equals("TITLESPOOFER.exe", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string randomFileName;
                do
                {
                    randomFileName = GenerateRandomString(random, 10) + ".exe";
                } while (File.Exists(Path.Combine(directoryPath, randomFileName)));

                string newFilePath = Path.Combine(directoryPath, randomFileName);
                File.Move(exeFile, newFilePath);
                Console.WriteLine($"Renamed {Path.GetFileName(exeFile)} to {randomFileName}");
            }

            Console.WriteLine("All applicable files have been renamed.");
        }

        static string GenerateRandomString(Random random, int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                // Generate a random Unicode character
                char randomChar = (char)random.Next(0x0020, 0xFFFF);
                sb.Append(randomChar);
            }
            return sb.ToString();
        }
    }
}
