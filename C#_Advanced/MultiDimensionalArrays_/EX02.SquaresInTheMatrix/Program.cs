namespace EX02.SquaresInTheMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Размери
            string[] dimensions = Console.ReadLine().Split(" ");
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            // Матрица
            string[,] matrix = new string[rows, cols];
            

            // Запълване
            for(int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for(int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            // Обхождане и преглед
            int relationShips = 0;
            for(int i = 0;i < matrix.GetLength(0)-1; i++)
            {
                for(int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&
                              matrix[i, j] == matrix[i + 1, j] &&
                              matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        relationShips++;
                    }
                }
            }
            Console.WriteLine(relationShips);
        }
    }
}
/*   int[,] matrix1 = new int[rows, cols];
   int[,] matrix2 = new int[rows, cols];
   int[,] matrix3 = new int[cols, rows];
                   /* matrix1[i, i] = input[j]);
           matrix2[j, j] = int.Parse(input[j]);
           matrix3[i, j] = int.Parse(input[j]);*/