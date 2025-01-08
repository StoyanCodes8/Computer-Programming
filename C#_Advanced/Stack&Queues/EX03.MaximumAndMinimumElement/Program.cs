using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace EX03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cycleLength = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int biggestNumber = 0;
            int smallestNumber = 0;
            /*int number3Index = 0;
            int number4Index = 0;
            int threeCount = 0;
            int fourCount = 0;*/
            Queue<int> queueIndex = new();
            string[] input;
            for(int i = 0; i < cycleLength; i++)
            {
                input = Console.ReadLine().Split(" ");
                switch (input[0])
                {
                        case "1":
                        int number = int.Parse(input[1]);
                        stack.Push(number);
                        break;

                        case "2":
                        stack.Pop();
                        break;

                        case "3":
                       foreach(var numbers in stack)
                        {
                            biggestNumber = stack.Max();
                        }
                        //threeCount++;
                        //number3Index = i;
                        queueIndex.Enqueue(biggestNumber);
                        break;

                        case "4":
                       foreach (var numbers in stack)
                        {
                            smallestNumber = stack.Min();
                        }
                        //fourCount++;
                        //number4Index = i;
                        queueIndex.Enqueue(smallestNumber);
                        break;
                }
            }
          
            bool isEmpty = stack.Count == 0;
            int counter = 0;
            if (!isEmpty)
            {
                foreach (var numbers in queueIndex)
                {
                    Console.WriteLine(numbers);
                }
                foreach (var numbers in stack)
                {
                    if(counter == stack.Count-1)
                    {
                        Console.Write($"{numbers}");
                    }
                    else if (counter < stack.Count)
                    {
                        Console.Write($"{numbers}, ");
                    }
                    counter++;
                }
            }      
        }
    }
}



/*  int command;
          for(int i = 0; i < cycleLength; i++)
          {
              while ((command = int.Parse(Console.ReadLine())) != cycleLength)
              {

              }
          }       */  