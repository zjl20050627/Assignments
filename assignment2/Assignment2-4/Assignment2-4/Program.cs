using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_4
{
    class ToeplitzMatrixValidator
    {
        static void Main(string[] args)
        {
            int[][] matrix = InputMatrix();
            bool isToeplitz = IsToeplitzMatrix(matrix);
            Console.WriteLine(isToeplitz);
        }
        static int[][] InputMatrix()
        {
            Console.WriteLine("请输入矩阵的行数和列数，以空格分开：");
            string[] dimensions = Console.ReadLine().Split(' ');
            int M = int.Parse(dimensions[0]);
            int N = int.Parse(dimensions[1]);

            int[][] matrix = new int[M][];
            Console.WriteLine("请逐行输入矩阵元素，以空格分隔：");
            for(int i = 0;i<M;i++)
            {
                string[] rowInput = Console.ReadLine().Split(' ');
                matrix[i] = new int[N];
                for(int j=0;j<N;j++)
                {
                    matrix[i][j] = int.Parse(rowInput[j]);
                }
            }
            return matrix;
        }
        static bool IsToeplitzMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for(int i=0;i<rows-1;i++)
            {
                for(int j=0;j<cols-1;j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j+1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
