namespace P05.ExtractSpecialBytes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string examplePng = Path.Combine(projectRoot, "example.png");
            string bytes = Path.Combine(projectRoot, "bytes.txt");
            string outputBinary = Path.Combine(projectRoot, "binary.bin");
            byte[] byteArray = ReadFileAndConvertToBytes(bytes);
            File.WriteAllBytes(outputBinary, byteArray);
        }

        static byte[] ReadFileAndConvertToBytes(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Select(line => Convert.ToByte(line)).ToArray();
        }
    }
}
