namespace P01.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedString = new Stack<char>();
            for(int i = 0; i <= input.Length-1; i++)
            {
                reversedString.Push(input[i]);
            }
            foreach(char c in reversedString)
            {
                Console.Write(c);
            }
        }
    }
}
