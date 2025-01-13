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
                for (int j = 0; j < cols; j++)
                {
                    jaggedMatrix[i][j] = int.Parse(rowData[j]);
                }
            }
        }
    }
}
