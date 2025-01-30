using System.Xml;
namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\Files\\input.txt";
            string outputFilePath = @"..\..\..\Files\\output.txt";
            TextOperation(inputFilePath, outputFilePath);
        }
        public static void TextOperation(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new(inputFilePath);
            if(!File.Exists(inputFilePath))
            {
                Console.WriteLine("File doesn't exist!");
            }
            using (reader)
            {
                string input = reader.ReadToEnd();
                Console.WriteLine(input);
            }
        }
    }
}
