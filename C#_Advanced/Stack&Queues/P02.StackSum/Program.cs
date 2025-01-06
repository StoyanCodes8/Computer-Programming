using System.Text.RegularExpressions;

namespace P02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split(" ");
            Stack<int> stack = new Stack<int>();
            string stackCommand = null;
            int additionalNumbers = 0;
            foreach(string input in inputArray)
            {
                int number = int.Parse(input);
                stack.Push(number);
            }

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                string endPattern = @"^[A-Za-z]{3}$";
                if (Regex.IsMatch(command, endPattern))
                {
                    break;
                }
                string[] array = command.Split(" "); // премахнах array2
                stackCommand = array[0];
                string addPattern = @"[A-a][D-d]{2}";
                string removePattern = @"[A-z]{6}";
                if (!string.IsNullOrEmpty(stackCommand))
                {
                    var resultAdd = Regex.Match(stackCommand, addPattern);
                    var resultRemove = Regex.Match(stackCommand, removePattern);
                    if (resultAdd.Success)
                    {
                        for (int i = 1; i < array.Length; i++)
                        {
                            int number = int.Parse(array[i]);
                            stack.Push(number);
                        }
                    }
                    else if (resultRemove.Success)
                    {
                        int numbersToRemove = int.Parse(array[1]);
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            if (stack.Count > 0) stack.Pop();
                        }
                    }
                    /*else
                    {
                        Console.WriteLine("No match found.");
                    }*/
                }
            }
            int sum = 0;    
            foreach(var item in stack)
            {
                sum+=item;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

// остава ми да оправя патърна на end