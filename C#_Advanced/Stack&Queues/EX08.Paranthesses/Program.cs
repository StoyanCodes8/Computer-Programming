namespace EX08.Paranthesses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<char> queue = new Queue<char>();
            Stack<char> reversedQueue = new();
            int mismatch = 0;

            if (input.Length % 2 == 0)
            {
                for (int i = 0; i < (input.Length / 2); i++)
                {
                    queue.Enqueue(input[i]);
                }
                for (int j = (input.Length / 2); j < input.Length; j++)
                {
                    reversedQueue.Push(input[j]);
                }

                // Проверяваме дали символите съвпадат като огледални
                while (queue.Count > 0 && reversedQueue.Count > 0)
                {
                    if (!IsMirror(queue.Dequeue(), reversedQueue.Pop()))
                    {
                        mismatch++;
                    }
                }
            }
            if (mismatch == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static bool IsMirror(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }
    }
}
