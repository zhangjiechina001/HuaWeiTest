using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipyListAverge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<Queue<int>> src = new List<Queue<int>>()
            {
                new Queue<int>(new List<int>(){0,1,2,3,4,5,6,7,8,9}),
                new Queue<int>(new List<int>(){10,11,12,13,14,15,16,17,18,19}),
                new Queue<int>(new List<int>(){20,21,22,23,24,25,26,27,28,29}),
            };

            for (int i = 0; i < 7;i++ )
            {
                int[] item=GetArray(src, 4);
                Console.WriteLine(string.Join(" ",item));
            }
            Console.ReadKey();
        }

        //static List<int[]> GetListAvaerage(List<Queue<int>> src,int rowCount,int colCount)
        //{
        //    List<List<int>> ret = new List<List<int>>();
        //    for (int i = 0; i < rowCount; i++)
        //    {
        //        ret.Add(new List<int>());
        //    }

        //    foreach (Queue<int> avaerage in src)
        //    {
        //        for (int i = 0; i < rowCount; i++)
        //        {
        //            ret[i].Add(avaerage.Dequeue());
        //        }
        //    }
        //}

        static int index = 0;
        static int[] GetArray(List<Queue<int>> src, int count)
        {
            List<int> ret = new List<int>();

            if (src[index].Count >= count)
            {
                for (int i = 0; i < count; i++)
                {
                    ret.Add(src[index].Dequeue());
                }
                index++;
                index = index % src.Count;
                return ret.ToArray();
            }
            else
            {
                for (int i = index; i < src.Count; i++)
                {
                    while (src[i].Any() && ret.Count<count)
                    {
                        ret.Add(src[i].Dequeue());
                        if (ret.Count == count)
                        {
                            break;
                        }
                    }
                    index++;
                    index = index % src.Count;
                }
            }

            return ret.ToArray();
        }
    }
}
