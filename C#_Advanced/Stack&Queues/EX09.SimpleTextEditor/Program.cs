using System.Text;

namespace EX09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsLength = int.Parse(Console.ReadLine());
            string[] input;
            Queue<string> strings = new Queue<string>();
            Queue<char> chars = new Queue<char>();
            Queue<char> chosenChars = new();
            StringBuilder text = new StringBuilder();//добавих това
            Stack<string> history = new(); //добавих това
            while (operationsLength > 0)
            {
                input = Console.ReadLine().Split(" ");
                switch(input[0])
                {
                    case "1":
                        history.Push(text.ToString()); //добавих това
                        text.Append(input[1]); // Добавих това
                        foreach (char c in input[1])
                        {
                            chars.Enqueue(c);
                        }
                        operationsLength--;
                        break;

                    case "2":
                        history.Push(text.ToString()); // Добавих това
                        int number = int.Parse(input[1]);
                        if (number <= text.Length) // Добавих това
                        {
                            text.Remove(text.Length - number, number); // Добавих това
                        }
                        operationsLength--;
                        break;

                    case "3":
                        int index = int.Parse(input[1]) - 1; // Добавих това
                        if (index >= 0 && index < text.Length) // 
                        {
                            chosenChars.Enqueue(text[index]); // Добавих това
                        }
                        operationsLength--;
                        break;

                        case "4":
                        if (history.Count > 0)
                        {
                            text = new StringBuilder(history.Pop()); // добавих това
                        }
                        operationsLength--;
                        break;
                }
            }
            foreach(var items in chosenChars)
            {
                Console.WriteLine(items);
            }
        }
    }
}


/* for(int i = 0;i < chars.Count; i++)
                      {
                        chars.Peek();
                          if(i == index)
                          {

                          }
                      }*/


// old case 2
/*   history.Push(text.ToString()); //&&
                           int number = int.Parse(input[1]);
                           for (int i = 0; i < number; i++)
                           {
                               chars.Dequeue();
                           }
                           operationsLength--;
                           break;*/
