using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTransMinString
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static string MinString(string src)
        {
            var order = src.OrderBy(x => x).ToArray();
            
            int index = 0;
            for (int i = 0; i < order.Length; i++)
            {
                if (src[i] != order[i]) 
                {
                    index = i;
                    break;
                }
            }

            int swapIndex = 0;
            for(int i= or)
        }
    }
}
