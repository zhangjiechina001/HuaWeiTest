using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTaskCount
{
    public class TaskItem
    {
        public TaskItem(int start,int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start;
        public int End;

        public override string ToString()
        {
            int starsCount = End - Start + 1; // 计算 * 的数量
            int spacesCount = Start - 1; // 计算空格的数量
            return new string(' ', spacesCount) + new string('*', starsCount);
        }
    }

    internal class Program
    {
        //原则，首先完成时间跨度最短的工作
        static void Main(string[] args)
        {
            List<TaskItem> taskItems1 = new List<TaskItem>()
            {
                new TaskItem(1, 4),
                new TaskItem(2, 3),
                new TaskItem(1, 2),
            };
            Console.WriteLine("测试用例1:");
            int max1 = GetMaxTaskCount1(taskItems1);
            Console.WriteLine($"可以处理的最大任务数: {max1}");

            // 测试用例2 - 博客中的案例
            List<TaskItem> taskItems2 = new List<TaskItem>()
            {
                new TaskItem(5, 6),
                new TaskItem(5, 5),
                new TaskItem(3, 7),
                new TaskItem(2, 6),
                new TaskItem(4, 9),
                new TaskItem(5, 8)
            };
            Console.WriteLine("测试用例2:");
            int max2 = GetMaxTaskCount1(taskItems2);
            Console.WriteLine($"可以处理的最大任务数: {max2}");

            // 测试用例3 - 复杂案例
            List<TaskItem> taskItems3 = new List<TaskItem>()
            {
                new TaskItem(1, 3),
                new TaskItem(2, 4),
                new TaskItem(3, 5),
                new TaskItem(4, 6),
                new TaskItem(5, 7),
                new TaskItem(6, 8),
                new TaskItem(7, 9),
                new TaskItem(8, 10)
            };
            Console.WriteLine("测试用例3:");
            int max3 = GetMaxTaskCount1(taskItems3);
            Console.WriteLine($"可以处理的最大任务数: {max3}");

            Console.ReadKey();
        }

        public static int GetMaxTaskCount(List<TaskItem> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                return 0;
            }
            var orders = tasks.OrderBy(t => t.Start).ThenBy(t => t.End).ToList();

            foreach (var item in orders)
            {
                Console.WriteLine(item.ToString());
            }


            int count = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (!orders.Any())
                {
                    break;
                }

                TaskItem item = GetFirstSuitItem(orders, i);
                if (item != null)
                {
                    orders.Remove(item);
                    count++;
                }
            }

            return count;
        }

        public static int GetMaxTaskCount1(List<TaskItem> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                return 0;
            }

            // 按照结束时间升序排序
            var orderedTasks = tasks.OrderBy(t => t.End).ToList();

            foreach (var item in orderedTasks)
            {
                Console.WriteLine($"{item.ToString()}");
            }

            // 用于记录每天是否已安排任务
            HashSet<int> occupiedDays = new HashSet<int>();
            int count = 0;

            foreach (var task in orderedTasks)
            {
                // 从任务的结束时间开始往前找，找到第一个未被占用的日期
                for (int day = task.End; day >= task.Start; day--)
                {
                    if (!occupiedDays.Contains(day))
                    {
                        // 找到一个可用的日期，安排任务
                        occupiedDays.Add(day);
                        count++;
                        break; // 这个任务已安排，处理下一个任务
                    }
                }
            }

            return count;
        }
        private static TaskItem  GetFirstSuitItem(List<TaskItem> tasks,int data)
        {
            foreach (TaskItem item in tasks)
            {
                if (data>=item.Start&&data<=item.End)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
