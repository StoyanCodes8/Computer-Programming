using System.Linq;

namespace EX01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] NSX = Console.ReadLine().Split(" ");
            int elementsToPush = int.Parse(NSX[0]);
            int elementsToPop = int.Parse(NSX[1]);
            int elementToCheck = int.Parse(NSX[2]);
            // Next
            string[] input = Console.ReadLine().Split(" ");
            if(input.Length > elementsToPush)
            {
                throw new Exception();
            }
            else
            {
                Stack<string> stack = new Stack<string>(input);
                for (int i = 0; i < elementsToPop; i++)
                {
                    stack.Pop();
                }
                //bool exists = stack.Contains(elementToCheck); // will find way - PROMISE
                bool exists = stack.Contains(NSX[2]);
                if (exists)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int[] array = stack.Select(s => int.Parse(s)).ToArray();
                    if(array.Length > 0)
                    {
                        int smallest = array.Min();
                        Console.WriteLine(smallest);
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                }
            }
        }
    }
}
