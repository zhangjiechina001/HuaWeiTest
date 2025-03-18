using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.MinDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String A = "ABCABBACCCAAA";
            String B = "CBABACAAACCC";
            Console.WriteLine("最短路径代价: " + ShortestPath(A, B));
        }


        static int ShortestPath(string a, string b) 
        {
            int m = a.Length;
            int n = b.Length;
            int[,] dp = new int[m+1,n+1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp[i, j] = int.MaxValue ;
                }
            }

            for (int j = 0; j <= n; j++)
            {
                dp[0, j] = j;  // 第一行初始化为从空串到 B 的编辑距离
            }

            // 初始化第一列
            for (int i = 0; i <= m; i++)
            {
                dp[i, 0] = i;  // 第一列初始化为从 A 到空串的编辑距离
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // 如果字符匹配，代价为 1
                    if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        // 如果字符不匹配，代价为 2（根据实际需求可以调整）
                        int min1 = Math.Min(dp[i - 1, j], dp[i, j - 1]) + 1;
                        int min2 =  dp[i - 1, j - 1] + 2;
                        if(min1 == min2)
                        {
                            Console.WriteLine($"min1：{min1} min2:{min2}");
                        }
                        else if (min1 != min2)
                        {
                            Console.WriteLine($"------ min1：{min1} min2:{min2}");
                        }
                        dp[i, j] = Math.Min(min1,min2);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
