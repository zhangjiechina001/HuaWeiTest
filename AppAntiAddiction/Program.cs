using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAntiAddiction
{
    class DataSrcItem
    {
        public string AppName;
        public int Level;
        public DateTime StartTime;
        public DateTime EndTime;
    }
    class DataSrc
    {
        public List<DataSrcItem> DataSrcList = new List<DataSrcItem>();

        public DateTime SearchTime;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        private static DataSrc GetSrc()
        {
            DataSrc ret= new DataSrc();
            return ret;
        }

        private DateTime GetFilterTime(DataSrc src)
        {
            List< DataSrcItem > filteredItems = new List< DataSrcItem >();
            DateTime dt = src.SearchTime;
            //先搜索满足要求的时间

            foreach (var item in src.DataSrcList)
            {
                if(dt>=item.StartTime && dt<=item.EndTime)
                {
                    filteredItems.Add(item);
                }
            }

            List<DataSrcItem>  orderedItems=filteredItems.OrderBy(t=>t.Level).ToList();
            if (orderedItems.Any()) 
            {
                
            }

        }

    }
}
