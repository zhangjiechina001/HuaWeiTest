using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.StringSplit2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "12abc-abcABC-4aB@";
            int len = 3;

            string[] list = input.Split('-');
            string first=list[0];
            string remian=string.Join("",list.Skip(1));

            string trans= CountCaptialLetter(remian) > CountLowcaseLetter(remian)?remian.ToUpper() :remian.ToLower();

            List<string> list1 = new List<string>() { first};
            list1.AddRange(SplitAsLength(trans,len));

            Console.WriteLine(string.Join("-",list));
            Console.ReadKey();
        }

        private static int CountCaptialLetter(string src)
        {
            return src.Count(t => t >= 'a' && t <= 'z');
        }

        private static int CountLowcaseLetter(string src)
        {
            return src.Count(t => t >= 'A' && t <= 'Z');
        }

        private static List<string> SplitAsLength(string src,int length)
        {
            List<string> ret = new List<string>();
            int index = 0;
            while (true)
            {
                ret.Add(src.Substring(index,length));
                index += length;
                if (index+ length > src.Length) 
                {
                    ret.Add(src.Substring(index));
                    break;
                }
            }
            return ret;
        }
    }
}
