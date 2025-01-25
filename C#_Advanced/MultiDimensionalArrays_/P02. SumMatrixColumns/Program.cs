namespace P02._SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(", ");
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[][] jaggedMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedMatrix[i] = new int[cols];
                string[] rowData = Console.ReadLine().Split(" ");
                
                if (rowData.Length != cols)
                {
                    throw new Exception($"The lengt is incorrect...Should be {cols} characters long!");
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        jaggedMatrix[i][j] = int.Parse(rowData[j]);
                    }
                }
            }
            int[] colSums = new int[cols];
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    colSums[col] += jaggedMatrix[row][col];
                }
            }
            foreach(var item in colSums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
