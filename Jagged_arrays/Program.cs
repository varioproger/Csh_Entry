namespace Jagged_arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            for (int i = 0; i < matrix.Length; i++)
            {
                // The inner dimensions aren’t specified in the declaration
                matrix[i] = new int[3]; // Create inner array
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = i * 3 + j;
                }
            }
            // or
            int[][] matrix2 = new int[][]
            {
             new int[] {0,1,2},
             new int[] {3,4,5},
             new int[] {6,7,8,9}
            };

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}