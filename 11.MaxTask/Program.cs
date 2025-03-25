using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MaxTask
{
    internal class Program
    {
        class TaskItem
        {
            public int Start;
            public int End;
        }

        private static int GetMaxTaskCount(List<TaskItem> items)
        {
            int[] taskCountArr = new int[100000];

            for (int i = 0; i < items.Count; i++)
            {
                TaskItem it = items[i];
                for (int j = it.Start - 1; j < it.End; j++)
                {
                    taskCountArr[j]++;
                }
            }
            return taskCountArr.Max();
        }
        static void Main(string[] args)
        {
            List<TaskItem> taskItems = new List<TaskItem>()
            {
                new TaskItem { Start = 1 ,End =2 },
                new TaskItem { Start = 3 ,End =3 },
                new TaskItem { Start = 3 ,End =4 },
                new TaskItem { Start =2 ,End =4 },
            };

            int maxTask = GetMaxTaskCount(taskItems);
            Console.WriteLine(maxTask);
            Console.ReadKey();
        }
    }
}
