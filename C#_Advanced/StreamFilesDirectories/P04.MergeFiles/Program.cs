using System.Runtime.CompilerServices;

namespace P04.MergeFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory
                .GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.FullName;
            string input = Path.Combine(projectRoot, "input.txt");
            string input1 = Path.Combine(projectRoot, "input1.txt");
            string output = Path.Combine(projectRoot, "output.txt");

            MergeFiles(input, input1, output);
        }

        public static void MergeFiles(string input, string input1, string output)
        {
            using (StreamReader reader = new(input))
            using (StreamReader reader1 = new(input1))
            using (StreamWriter writer = new(output))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    string line1 = reader1.ReadLine();
                    if(line == null &&  line1 == null)
                    {
                        break;
                    }
                    if (line != null)
                    {
                        writer.WriteLine(line);
                    }
                    if (line1 != null)
                    {
                        writer.WriteLine(line1);
                    }
                }
            }
        }
    }
}
