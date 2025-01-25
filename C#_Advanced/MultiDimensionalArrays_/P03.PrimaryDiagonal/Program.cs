namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cols = int.Parse(Console.ReadLine());
            int rows = cols;
            int[,] matrix = new int[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                string[] rowData = Console.ReadLine().Split(" ");
                if (rowData.Length != cols)
                {
                    throw new Exception($"The lengt is incorrect...Should be {cols} characters long!");
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(rowData[j]);
                    }
                }
            }
            int sum = 0;
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[i, j];
                    i++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}


/*string[] dimensions = Console.ReadLine().Split(", ");
           int rows = int.Parse(dimensions[0]);
           int cols = int.Parse(dimensions[1]);
           int[][] jaggedArray = new int[rows][];
           for (int i = 0; i < rows; i++)
           {
               jaggedArray[i] = new int[cols];
               string[] rowData = Console.ReadLine().Split(" ");

               if (rowData.Length != cols)
               {
                   throw new Exception($"The lengt is incorrect...Should be {cols} characters long!");
               }
               else
               {
                   for (int j = 0; j < cols; j++)
                   {
                       jaggedArray[i][j] = int.Parse(rowData[j]);
                   }
               }
           }
           for(int i = 0;i < rows; i++)
           {
               for(int j = 0; j < cols; j++)
               {

               }
           }
       }*/