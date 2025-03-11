using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.BossIncome
{
    class Customer
    {
        public int Id { get; set; }
        public int SalesValue { get; set; }
        public List<Customer> LowerCustoms { get; } = new List<Customer>();

        public int CalcTotalValues()
        {
            int ret = 0;
            foreach (var item in LowerCustoms)
            {
                double val =(double)(item.CalcTotalValues())*0.15;
                ret = ret + (int)val;
            }
            ret += SalesValue;
            return ret;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Customer> customerDic = GetSrcData();

            foreach (var item in customerDic)
            {
                Console.WriteLine($"{item.Key}:{item.Value.CalcTotalValues()}" );
            }
            Customer boss = customerDic[0];
            
            Console.ReadKey();

        }

        static Dictionary<int, Customer> GetSrcData()
        {
            List<string> src = new List<string>()
            {
                "1 0 223",
                "2 0 323",
                "3 2 323",
                "4 2 1203"
            };

            Dictionary<int, Customer> ret = new Dictionary<int, Customer>();
            ret.Add(0,new Customer() { Id=0,SalesValue=0});

            for (int i = 0; i < src.Count; i++)
            {
                string[] arr = src[i].Split(' ');
                int id = int.Parse(arr[0]);
                int upperId = int.Parse(arr[1]);
                int sales = int.Parse(arr[2]);

                if(!ret.ContainsKey(id))
                {
                    Customer customer = new Customer() { Id = id };
                    ret.Add(id, customer);
                }
                ret[id].SalesValue = sales;


                if (!ret.ContainsKey(upperId))
                {
                    Customer customer = new Customer() { Id = upperId, };
                    ret.Add(upperId, customer);
                }

                ret[upperId].LowerCustoms.Add(ret[id]);

            }

            return ret;
        }
    }
}
