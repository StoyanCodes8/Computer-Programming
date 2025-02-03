using System.Buffers;

namespace P06.Split_Merge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory
                .GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.FullName;
            string inputFilePath = Path.Combine(projectRoot, "example.png");
            string outputFile1 = Path.Combine(projectRoot, "part-1.bin");
            string outputFile2 = Path.Combine(projectRoot, "part-2.bin");
            string mergedFilePath = Path.Combine(projectRoot, "example-joined.png");
            SplitFile(inputFilePath, outputFile1, outputFile2);
            MergeFiles(outputFile1, outputFile2, mergedFilePath);
        }

        public static void SplitFile(string inputFilePath, string outputFile1, string outputFile2)
        {
            byte[] data = File.ReadAllBytes(inputFilePath);
            int halfLength = data.Length / 2;
            int secondPartLength = data.Length - halfLength;
            // създавам нови байтове
            byte[] data1 = new byte[halfLength];
            byte[] data2 = new byte[secondPartLength];

            Array.Copy(data, 0, data1, 0, halfLength);
            Array.Copy(data, halfLength, data2, 0, secondPartLength);

            File.WriteAllBytes(outputFile1, data1);
            File.WriteAllBytes(outputFile2, data2);
        }

        public static void MergeFiles(string file1, string file2, string outputFile)
        {
            using (FileStream output = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                byte[] part1 = File.ReadAllBytes(file1);
                byte[] part2 = File.ReadAllBytes(file2);

                output.Write(part1, 0, part1.Length);
                output.Write(part2, 0, part2.Length);
            }
        }
    }
}
// не знам дали така трябва да работи кода

/*    using (FileStream input1 = new FileStream(file1, FileMode.Open, FileAccess.Read))
                   {
                       input1.CopyTo(output);
                   }

                   using (FileStream input2 = new FileStream(file2, FileMode.Open, FileAccess.Read))
                   {
                       input2.CopyTo(output);
                   }*/