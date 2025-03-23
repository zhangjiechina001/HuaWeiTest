using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.HappyXiaoXiaoLe
{
    internal class Program
    {
        class DataSrc
        {
            public int[,] Data;
        }

        private static int[,] GetDataSrc()
        {
            string line1 = Console.ReadLine();
            int rows = int.Parse(line1.Split(' ')[0]);
            int cols = int.Parse(line1.Split(' ')[1]);

            int[,] ret = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                int[] arr = line.Split(' ').Select(t=>int.Parse(t)).ToArray();
                for (int j = 0;j< cols; j++)
                {
                    ret[i,j] = arr[j];
                }
            }
            return ret;
        }

        static List<Tuple<int, int>> DfsPosition = new List<Tuple<int, int>>
        {
            Tuple.Create(-1, 1),
            Tuple.Create(0, 1),
            Tuple.Create(1, 1),
            Tuple.Create(-1, 0),
            Tuple.Create(1, 0),
            Tuple.Create(-1, -1),
            Tuple.Create(0, -1),
            Tuple.Create(1, -1),
        };

        static void Dfs(int[,] matrix,int xPos,int yPos)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if(xPos < 0 || yPos < 0 || xPos>=row || yPos>=col)
            {
                return;
            }

            if (matrix[xPos,yPos] == 0)
            {
                return;
            }
            else
            {
                matrix[xPos, yPos] = 0;

                foreach (var item in DfsPosition)
                {
                    Dfs(matrix, xPos + item.Item1, yPos + item.Item2);
                }
            }
        }

        static int MinClicksToZero(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int ret = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row, col] == 1)
                    {
                        Dfs(matrix, row, col);
                        ret++;
                    }
                }
            }
            return ret;
        }

        static void Main(string[] args)
        {
            int[,] matrix = GetDataSrc();
            int min = MinClicksToZero(matrix);
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}
