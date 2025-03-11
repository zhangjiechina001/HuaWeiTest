using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.DividPizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max=MaxPizza(new List<int>() { 8, 2, 10, 5, 7 });
            Console.WriteLine(max);
            Console.ReadKey();
        }

        static int MaxPizza(List<int> src)
        {
            List<int> extendSrc = new List<int>(src);
            extendSrc.AddRange(src);
            List<int> ret=new List<int>();
            for (int i = 0; i < src.Count; i++)
            {
                List<int> temp = extendSrc.Skip(i).Take(src.Count).ToList();
                ret.Add(MaxPizzaPos(temp));
            }

            return ret.Max();
        }

        private static int MaxPizzaPos(List<int> src)
        {
            List<int> chihuo = new List<int>();
            List<int> zuichan = new List<int>();
            bool isChihuo = true;
            while(src.Any())
            {
                if (isChihuo)
                {
                    if (src.First() > src.Last())
                    {
                        chihuo.Add(src.First());
                        src.RemoveAt(0);
                    }
                    else
                    {
                        chihuo.Add(src.Last());
                        src.RemoveAt(src.Count - 1);
                    }
                }
                else
                {
                    if (src.First() > src.Last())
                    {
                        zuichan.Add(src.First());
                        src.RemoveAt(0);
                    }
                    else
                    {
                        zuichan.Add(src.Last());
                        src.RemoveAt(src.Count - 1);
                    }
                }

                isChihuo = !isChihuo;   
            }

            return chihuo.Sum(x => x);
        }
    }
}
