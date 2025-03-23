using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        class PressItem
        {
            public char Char;
            public int Length;
        }

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string compress = CompressString(line);
            Console.WriteLine(compress);
            Console.ReadKey();
        }

        private static string CompressString(string input)
        {
            string temp = input.ToLower();
            List<char> filter = new List<char>();
            foreach (char c in temp)
            {
                if(c>='a'&&c<='z')
                {
                    filter.Add(c);
                }
            }
            filter.Add((char)0);

            List<PressItem> items= new List< PressItem >();
            int tempIndex = 0;
            for (int i = 0; i < filter.Count-1; i++)
            {
                tempIndex++;
                if (filter[i] != filter[i+1])
                {
                    items.Add(new PressItem() { Char = filter[i], Length = tempIndex });
                    tempIndex = 0;
                }
            }

            List<PressItem> filterItems = new List<PressItem>();
            //HashSet<char> singleSet = new HashSet<char>();
            for (int i = 0; i < items.Count; i++)
            {
                PressItem curItem = items[i];
                //if(singleSet.Contains(curItem.Char))
                //{
                //    continue;
                //}

                if (curItem.Length==1)
                {
                    //if(!singleSet.Contains(curItem.Char))
                    //{
                    //    int count = items.Where(t => t.Char == curItem.Char).Sum(t => t.Length) - 1;
                    //    singleSet.Add(curItem.Char);
                    //    filterItems.Add(new PressItem() { Char = curItem.Char,Length = count});
                    //}
                    int count = items.Skip(i).Where(t => t.Char == curItem.Char).Sum(t => t.Length) -1;
                    //singleSet.Add(curItem.Char);
                    filterItems.Add(new PressItem() { Char = curItem.Char, Length = count });
                }
                else
                {
                    filterItems.Add(curItem);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in filterItems.OrderByDescending(t=>t.Length).ThenBy(t=>t.Char))
            {
                sb.Append($"{item.Char}{item.Length}");
            }
            return sb.ToString();
        }
    }
}
