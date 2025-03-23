using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    internal class Program
    {
        class DataSrc
        {
            public int[] Array;
            public int Value;
        }
        static void Main(string[] args)
        {
            DataSrc src=GetSrc();
            var allArr = GetSubArray(src.Array).ToList();
            int ret=allArr.Count(t => IsGoodArray(t, src.Value));
            Console.WriteLine(ret);
        }

        private static DataSrc GetSrc()
        {
            DataSrc ret = new DataSrc();
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            ret.Array = line2.Split(' ').Select(t=>int.Parse(t)).ToArray();
            ret.Value = int.Parse(line1.Split(' ')[1]);
            return ret;
        }

        private static List<int[]> GetSubArray(int[] arr)
        {
            List<int[]> input = new List<int[]>();
            for (int i = 1; i <= arr.Length; i++)
            {
                List<int[]> temp = GetSubArray2(arr, i);
                input.AddRange(temp);
            }
            return input;
        }

        private static bool IsSubArray(int[] src, int[] target)
        {
            string str1 = string.Join(" ", src);
            string str2 = string.Join(" ", target);
            return str1.Contains(str2);
        }

        private static List<int[]> GetSubArray1(List<int[]> arr,int val)
        {
            List<int[]> ret = new List<int[]>(arr.ToArray());
            int maxLeng = arr.Any() ? arr.Max(t => t.Length): 0;

            for (int i = 0; i<arr.Count;i++)
            {
                List<int> aItem = new List<int>(arr[i]);
                aItem.Add(val);
                ret.Add(aItem.ToArray());
            }
            
            foreach (int[] arr2 in arr)
            {
                List<int> aItem = new List<int>(arr2);
                aItem.Add(val);
                ret.Add(aItem.ToArray());
            }

            ret.Add(new int[] { val });
            return ret;
        }

        private static List<int[]> GetSubArray2(int[] arr, int length)
        {
            List<int[]> ret = new List<int[]>();

            for(int i=0;i<=arr.Length-length;i++)
            {
                ret.Add(arr.Skip(i).Take(length).ToArray());
            }

            return ret;
        }

        private static bool IsGoodArray(int[] arr,int src)
        {
            Dictionary<int,int> keyValuePairs = new Dictionary<int,int>();
            foreach (int item in arr)
            {
                if(!keyValuePairs.ContainsKey(item))
                {
                    keyValuePairs.Add(item, 0);
                }
                keyValuePairs[item]++;  
            }
            int maxCount = keyValuePairs.Max(t=>t.Value);
            return maxCount >= src;
        }
    }
}
