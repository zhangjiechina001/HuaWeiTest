using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.BestPoint
{
    struct Point
    {
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point Add(int xOff,int yOff)
        {
            int x1 = this.x + xOff;
            int y1 = this.y + yOff;
            return new Point(x1,y1);
        }

        public bool CheckBound(Point bound)
        {
            if (this.x >= 0 && this.x <= bound.x && this.y >= 0 && this.y <= bound.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            Point p = (Point)obj;
            return p.x==this.x && p.y==this.y;
        }

        int x;
        int y;
    }

    class Horse
    {
        public int MaxStep { get; set; }
        public Point StartPos { get; set; }

        public List<Point> GetAllReached(Point bound)
        {
            List<Point> result = new List<Point>();
            List<Point> points = RunOneTime(StartPos, bound);

            List<Point> lastLevel = new List<Point>() { StartPos };
            result.AddRange(lastLevel);
            for (int i = 0; i < MaxStep; i++)
            {
                List<Point> temp =new List<Point>();
                foreach (Point p in lastLevel)
                {
                    List<Point> ts = RunOneTime(p, bound);
                    temp.AddRange(ts);
                }
                temp = temp.Distinct().ToList();
                result.AddRange(temp);
                lastLevel = temp;
            }
            return result.Distinct().ToList();
        }

        private List<Point> RunOneTime(Point pos,Point bound)
        {
            List<Point> result = new List<Point>();

            result.Add(pos.Add(1, 2));
            result.Add(pos.Add(1, -2));
            result.Add(pos.Add(2, 1));
            result.Add(pos.Add(2, -1));
            result.Add(pos.Add(-1, 2));
            result.Add(pos.Add(-1,-2));
            result.Add(pos.Add(-2, 1));
            result.Add(pos.Add(-2,-1));

            var temp = result.Where(t => t.CheckBound(bound)).ToList(); 
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Horse horse = new Horse()
            {
                StartPos = new Point(0, 0),
                MaxStep = 10
            };
            var allPos = horse.GetAllReached(new Point(20, 20));
            Console.WriteLine(allPos.Count);
        }
    }
}
