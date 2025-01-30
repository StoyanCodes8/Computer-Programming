using System.Reflection.PortableExecutable;

namespace P01.OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string inputFilePath = Path.Combine(projectRoot, "input.txt");
            string outputFilePath = Path.Combine(projectRoot, "output.txt");
            TextOperation(inputFilePath, outputFilePath);
        }
        public static void TextOperation(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new(inputFilePath)) 
            using (StreamWriter writer = new(outputFilePath))
            {
                string line;
                int cycleLength = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if(cycleLength %2 != 0)
                    {
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                    }
                    cycleLength++;
                }
            }
        }
    }
}