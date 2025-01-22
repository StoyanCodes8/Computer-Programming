namespace EX05.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            string snake = Console.ReadLine();
            // ТРЯБВА ДА ЗАПЪЛНИМ матрицата с думата снейк

            // Create Object Matrix
            object[,] matrix = new object[rows, cols];

            // Fill the matrix with the snake
            int counter = 0;
            Queue<char> queue = new Queue<char>();
            Stack<char> stack = new Stack<char>();
            Queue<char> secondQueue = new Queue<char>();
            // Запълване и добавяне
            for (int i = 1; i <= rows; i++)
            {
               for (int k = 0; k < snake.Length;)
               {
                    if(i%2!=0)
                    {
                        queue.Enqueue(snake[k]);
                        Console.Write($"{queue.Dequeue()} ");
                    }
                    else if(i%2==0)
                    {
                        secondQueue.Enqueue(snake[k]);
                        Console.Write($"{secondQueue.Dequeue()} ");
                    }
                    if (k == cols - i)
                    {
                       i++;
                       Console.WriteLine();
                       counter++;
                    }
                    if (k == snake.Length - 1)
                    {
                       k = -1;
                    }
                    k++;
                    if (counter == rows)
                    {
                      break;
                    }
               }
            }
            // Обхождане и принтиране          
        }
    }
}
// matrix[i, j] = snake[i]; - но индекс от i се върти само до дължината на колоните, а думата може да е по-дълга
// matrix[i, j] = snake[(i * cols) + j];
/*
              if (k == snake.Length)
              {
                  k = 0;
              }

                  if (k  == cols)
              {
                  Console.WriteLine();
                  i++;
                  j = 0;
              }
              Console.WriteLine(k);
}*/