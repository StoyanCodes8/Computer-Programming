using System.Xml;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("addedFromC#");
           // using (FileStream fs = new FileStream("example.txt", FileMode.Open))
            {

            }
            string file = "example.txt";
            bool fileExists = File.Exists(file);

            if (fileExists)
            {
                Console.WriteLine($"{file} exists");
            }
            else
            {
                Console.WriteLine($"{file} doesn't exist");
            }

        }
    }
}
