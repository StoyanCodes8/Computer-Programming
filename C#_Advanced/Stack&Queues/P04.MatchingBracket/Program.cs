using System.Text.RegularExpressions;

namespace P04.MatchingBracket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           /* int firtsBracket = input.IndexOf('(');
            int lastBracket = input.LastIndexOf(")");*/
            // Тука сме с опашка
            Stack<string> stack = new();
            string firstPattern = @"\((.*)\)";
            foreach (Match match in Regex.Matches(input, firstPattern))
            {
                string valid = string.Join("", match);
                stack.Push(valid);
            }
            string secondPatern = @"\((?<FirstNumber>\d{0,3}) (?<MathSign>[+-]) (?<LastNumber>\d{0,3})\)";
            foreach (Match match in Regex.Matches(input, secondPatern))
            {
                string valid = string.Join("", match);
                stack.Push(valid);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
