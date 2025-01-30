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
        public static void Operations (string inputFilePath, string outputFilePath, string requirementsFilePath)
       {
            StreamReader readerRequierments = new StreamReader(requirementsFilePath);
              StreamReader readerInput = new StreamReader(inputFilePath);
              StreamWriter writer = new StreamWriter(outputFilePath);
              HashSet<string> specialWords = new();
              Dictionary<string, int> keyValuePairs = new();
              string line;

            // static trackWords?

            while ((line = readerRequierments.ReadLine()) != null)
            {
                string[] words = line.Split(" ");
                foreach(string word in words)
                {
                  specialWords.Add(word);
                }
            }
            while((line = readerInput.ReadLine()) != null)
            {
              //for(int i = 0; i < line.Length; i++)
                {
                    string[] modifiedLine = Regex.Split(line, @"\w[A-Za-z]+");
                    foreach (string word in modifiedLine)
                    {
                        if(specialWords.Contains(word)) // dots are recognized and fault. is not being added
                        {
                            if(!keyValuePairs.ContainsKey(word))
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
            }
            foreach(var items in  keyValuePairs)
            {
                writer.WriteLine($"{items.Key} - {items.Value}");
            }
        }
    }
}
