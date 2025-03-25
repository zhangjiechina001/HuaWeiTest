
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.ContinueCharLeng
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> lenDic= new Dictionary<string,int>();
            List<string> list = SplitAsNoSame("LALALAHAHAMAKABBBAKA");
            foreach (var item in list)
            {
                if (!lenDic.ContainsKey(item))
                {
                    lenDic[item] = item.Length;
                }
                else if (lenDic.ContainsKey(item) && item.Length > lenDic[item])
                {
                    lenDic[item] = item.Length;
                }
            }

            var arr=lenDic.OrderByDescending(t=>t.Value).ToArray();
            Console.WriteLine(arr[1].Value);
            Console.ReadKey();
        }

        static List<string> SplitAsNoSame(string input)
        {
            List<string> ret = new List<string>();
            int start = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    ret.Add(input.Substring(start, i - start + 1));
                    start = i + 1;
                }
                if (i == input.Length - 2)
                {
                    ret.Add(input.Substring(start));
                }
            }
            return ret;
        }
    }
}
