using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.EnglistInput
{
    class SrcData
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            SrcData srcData = GetSrcData();
            List<string> list = GetAssociate(srcData);
            Console.WriteLine(string.Join(" ",list));
            Console.ReadKey();
        }

        static SrcData GetSrcData()
        {
            SrcData ret = new SrcData();
            ret.Line1 = Console.ReadLine();
            ret.Line2 = Console.ReadLine();
            return ret;
        }

        static List<string> GetAssociate(SrcData data)
        {
            string[] list = data.Line1.Split(' ','\'');
            string[] first = list.Where(t=>t.StartsWith(data.Line2)).OrderBy(t=>t.Length).ToArray();
            return first.ToList();
        }

    }
}
