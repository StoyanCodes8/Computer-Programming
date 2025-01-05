namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Push Operations
           /* Stack<int> stack = new Stack<int>();
            stack.Push(10); // Добавя 10 на върха
            stack.Push(20); // Добавя 20 над 10*/

            // Малка задачка
            int stackLength = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < stackLength; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
                Console.WriteLine($"This is that last number of your stack");
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


            int queueLength = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < queueLength; i++)
            {
                queue.Enqueue(int.Parse(Console.ReadLine()));
                if (i == 0)
                {
                    Console.WriteLine("This is the first number");
                }
                else
                {
                    Console.WriteLine("This number is after the first one");
                }
            }
            foreach (var item in queue)
            {
            }
        }
    }
}

