using System.Runtime.InteropServices;

namespace EX04.MatruxShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(" ");
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            object[,] matrix = new object[rows, cols];
            string message = null;


            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }
            string command;
            Queue<string> strings = new Queue<string>();
            var variable1;
            int number2 = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ");
                string word = input[0];
                if (word != "swap")
                {
                    message = "Invalid input!";
                    strings.Enqueue(message);
                }
                // Number 1
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                if (row > rows || col > cols)
                {
                    message = "Invalid input!";
                    strings.Enqueue(message);
                }
                else if (row <= rows || col <= cols)
                {
                    number = matrix[row, col];
                }


                // Number 2
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);
                if (row2 > rows || col2 > cols)
                {
                    message = "Invalid input!";
                    strings.Enqueue(message);
                }
                number2 = matrix[row2, col2];

                // Swapping
                matrix.SetValue(number2, row, col);
                matrix.SetValue(number, row2, col2);
                // ?? ??? ?? ?????? ?? ??????? ???? ?????????, ?? ?? ? ????, ? ?????? ?? ?? ???????
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        string text = (matrix[i, j] + " ");
                        strings.Enqueue(text);
                    }
                    strings.Enqueue("\n");
                }
            }
            foreach (string item in strings)
            {
                Console.Write($"{item}");
            }
        }
    }
}