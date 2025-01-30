using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace P03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = Directory
                .GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.FullName;
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
            // GLOBAL VARIABLES
            HashSet<string> specialWords = new();
            Dictionary<string, int> keyValuePairs = new();
            string line;

            using (StreamReader readerRequierments = new StreamReader(requirementsFilePath))
            {
                while ((line = readerRequierments.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    foreach (string word in words)
                    {
                        specialWords.Add(word);
                    }
                }
            }

            using (StreamReader readerInput = new StreamReader(inputFilePath))
            {
                while ((line = readerInput.ReadLine()) != null)
                {
                    string pattern = @"[A-Za-z]+";
                    var result = Regex.Matches(line, pattern);
                    foreach (Match match in result)
                    {
                        string word = match.Value.ToLower();
                        if (specialWords.Contains(word.ToLower()))
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
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    var sortedDictionary = keyValuePairs.OrderByDescending(s => s.Value);
                    foreach (var items in sortedDictionary)
                    {
                        writer.WriteLine($"{items.Key} - {items.Value}");
                    }
                }
            }
        }
    }
}
