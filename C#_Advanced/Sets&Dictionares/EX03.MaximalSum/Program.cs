namespace EX03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Normal dimension
            string[] dimensions = Console.ReadLine().Split(" ");
            int N = int.Parse(dimensions[0]);
            int M = int.Parse(dimensions[1]);

            // Outer matrix
            int[,] matrix = new int[N, M];

            // Cycle
            for(int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for(int j = 0; j < M; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }
            // ЗАПОЧВАМЕ ОТ N,ЦИКЛИМ ДОКАТО НЕ СТИГНЕМ КРАЯ НА M, j
            Queue<int> queue = new Queue<int>();
            Stack<int[]> winningCoordinates = new();
            int maxSum = int.MinValue;
            for (int i = 0; i <= N - 3; i++)
            {
              for(int j = 0;j <= M - 3; j++)
                {
                    int sum = 0;
                    // обхождане на елементите
                    for(int k = 0; k < 3; k++) // rows
                    {
                        for(int l = 0; l < 3; l++)
                        {
                            sum += matrix[i + k, j + l];
                            // трябва след всяко приключване да съхранявам, защото после пак се пресмята
                        }
                    }
                    queue.Enqueue(sum);
                    if (sum > maxSum)
                    {
                        int desiredStartRow = i;
                        int desiredStartColl = j;
                        winningCoordinates.Push(new int[] { desiredStartRow, desiredStartColl });   
                        maxSum = sum;
                    }
                }
            }
            // Извеждаме координатите на желаната матрица
            int[] coordinates = winningCoordinates.Pop();
            int row = coordinates[0];
            int col = coordinates[1];
            // Попълваме желаната матрица
            int[,] desiredMatrix = new int[3, 3];
            for(int i = 0;i < 3;i++)
            {
                for(int j = 0; j < 3;j++)
                {
                    desiredMatrix[i, j] = matrix[row + i, col + j];
                }
            }

            // Обхождаме попълнената матрица
            Console.WriteLine($"Sum = {maxSum}");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    Console.Write(desiredMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
/*1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16*/



/*   // Hidden Matrix
           int sum = 0;
           Queue<string> queue = new Queue<string>();
           for(int i = 1; i < outterMatrix.GetLength(0); i++)
           {
               for(int j = 1;  j < outterMatrix.GetLength(1)-1; j++)
               {
                  sum+=outterMatrix[i, j];
                  //Console.Write(outterMatrix[i, j]  + " ");
               }
           }
           // Final Result
           Console.WriteLine($"Sum = {sum}");
           for (int i = 1; i < outterMatrix.GetLength(0); i++)
           {
               for (int j = 1; j < outterMatrix.GetLength(1) - 1; j++)
               {
                   Console.Write(outterMatrix[i, j]  + " ");
               }
               Console.WriteLine();
           }
*/