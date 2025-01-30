namespace P02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string inputFilePath = Path.Combine(projectRoot, "input.txt");
            string outputFilePath = Path.Combine(projectRoot, "output.txt");
            Operation(inputFilePath, outputFilePath);
        }
        public static void Operation(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new(inputFilePath))
            using (StreamWriter writer = new(outputFilePath))
            {
                int number = 0;
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine($"{++number}. {line}");
                }
            }
        }
    }
}