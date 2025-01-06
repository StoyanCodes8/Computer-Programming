using System.IO.Pipes;

namespace P03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new();
            string input = Console.ReadLine();
            for(int i = 0; i <= input.Length-1; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    int number = input[i] - '0';
                    stack.Push(number);
                }                      
                if (input[i] == '-')
                {
                    int number = input[i] - '0';
                    stack.Pop();
                } 
            }
            int sum = 0;
            foreach(var item in stack)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
