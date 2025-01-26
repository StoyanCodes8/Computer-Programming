namespace EX05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> input = new();
            string text = Console.ReadLine();
            foreach (char character in text)
            {
                if (!input.ContainsKey(character))
                {
                    input.Add(character, 1);
                }
                else
                {
                    input[character]++;
                }
            }
            foreach (var item in input)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
