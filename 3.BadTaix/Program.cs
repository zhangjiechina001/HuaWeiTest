using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.BadTaix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badValue = 0;
            int actualValue = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while(true)
            {
                int zeroCount = 0;
                badValue++;
                actualValue++;
                if (IsBadValue(badValue,ref zeroCount))
                {
                    badValue=badValue+(int)Math.Pow(10,zeroCount);
                }

                if(badValue==1000)
                {
                    Console.WriteLine(actualValue);
                    break;
                }
            }
        }

        static bool IsBadValue(int src, ref int zeroCount)
        {
            int srcCopy = src;
            int zeroCountTemp = 0;
            while (srcCopy % 10 == 0 && srcCopy / 10 != 0)
            {
                zeroCountTemp++;
                srcCopy /= 10;
            }

            if (srcCopy % 10 == 4)
            {
                zeroCount = zeroCountTemp;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
