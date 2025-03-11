using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _4.TLV
{
    class SrcData
    {
        public string Line;
        public int TagCount;
        public int Tag;
    }

    class TagInfo
    {
        public bool IsOk;
        public int Length;
        public int ValueOffset;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] src = { 0x0f, 0x04, 0xab, 0xab, 0xab, 0xab, 0xab, 0x0f, 0x03, 0xab, 0xab, 0xab };

            List<TagInfo> dst = new List<TagInfo>();  

            for (int i = 0;i<2;i++)
            {
                TagInfo tag = GetFirstInfo(src, 15);
                if (tag.IsOk)
                {
                    dst.Add(tag);
                    src = src.Skip(tag.ValueOffset + tag.Length).ToArray();
                }
                else
                {
                    break;
                }
            }
            foreach (var item in dst)
            {
                Console.WriteLine($"{item.Length} {item.ValueOffset}");
            }

            Console.ReadKey();
        }

        static TagInfo GetFirstInfo(byte[] src,int tag)
        {
            for (int i = 0; i < src.Length-2; i++)
            {
                if(src[i] == (byte)tag)
                {
                    int len = src[i + 1];
                    return new TagInfo() { IsOk = true, Length = len,ValueOffset= i+2 };
                }
            }

            return new TagInfo() { IsOk = false};
        }
    }
}
