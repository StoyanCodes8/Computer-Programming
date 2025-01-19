using System.Data.Common;

namespace EX01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int[,] array = new int[sum, sum];
            PrintArray(array, sum);
        }
        public static void PrintArray(int[,] array, int sum)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                    sum += array[i, j];
                }
            }
            Console.WriteLine(array.GetLength(0));
            Console.WriteLine(array.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
