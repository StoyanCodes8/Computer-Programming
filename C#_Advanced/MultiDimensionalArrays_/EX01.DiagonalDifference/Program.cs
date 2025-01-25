using System.Data.Common;
using System.Runtime.InteropServices;

namespace EX01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int sum = 0;
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = int.Parse(input[j]);
                }
            }
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, rows - i - 1];
            }
            if(primaryDiagonal > secondaryDiagonal)
            {
                 result = primaryDiagonal - secondaryDiagonal;
            }
            else
            {
                 result = secondaryDiagonal - primaryDiagonal;
            }
            Console.WriteLine(result);
        }
    }
}
