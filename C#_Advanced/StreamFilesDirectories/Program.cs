using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace P03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string inputFilePath = Path.Combine(projectRoot, "mainText.txt");
            string outputFilePath = Path.Combine(projectRoot, "output.txt");
            string requirementsFilePath = Path.Combine(projectRoot, "trackWords.txt");

            Operations(inputFilePath, outputFilePath, requirementsFilePath);
        }

        public static void Operations(
            string inputFilePath,
            string outputFilePath,
            string requirementsFilePath
        )
        {
            using StreamReader readerRequierments = new StreamReader(requirementsFilePath);
            using StreamReader readerInput = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            HashSet<string> specialWords = new();
            Dictionary<string, int> keyValuePairs = new();
            string line;

            while ((line = readerRequierments.ReadLine()) != null)
            {
                string[] words = line.Split(" ");
                foreach (string word in words)
                {
                    specialWords.Add(word);
                }
            }

            while ((line = readerInput.ReadLine()) != null)
            {
                string pattern = @"[A-Za-z]+";
                var result = Regex.Matches(line, pattern);
                foreach (Match match in result)
                {
                    string word = match.Value;
                    if (specialWords.Contains(word).ToLower())
                    {
                        if (!keyValuePairs.ContainsKey(word))
                        {
                            keyValuePairs.Add(word, 1);
                        }
                        else
                        {
                            keyValuePairs[word]++;
                        }
                    }
                }
            }

            foreach (var items in keyValuePairs)
            {
                writer.WriteLine($"{items.Key} - {items.Value}");
            }
        }
    }
}
