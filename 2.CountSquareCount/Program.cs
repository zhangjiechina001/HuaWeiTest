using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2.CountSquareCount
{
    class Point
    {
        public int x;
        public int y;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>()
            {
                new Point(){x=0,y=0},
                new Point(){x=1,y=0},
                new Point(){x=1,y=1},
                new Point(){x=0,y=1}
            };
            List < List < Point >> pointsList=Ge
            bool a  = IsSquare(points);
            Console.WriteLine(a);
        }

        private static List<List<Point>> GenerateAllData(List<Point> points)
        {
            List<List<Point>> ret = new List<List<Point>>();

            int len = points.Count;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    for (int k = 0; k < len; k++)
                    {
                        for (int l = 0; l < len; l++)
                        {
                            ret.Add(new List<Point>() { points[i], points[j], points[k], points[l] });
                        }
                    }
                }
            }
            return ret;
        }

        private static bool IsSquare(List<Point> points)
        {
            List<Point> order = points.OrderBy(p => p.x).ToList();

            Point p1 = order[0];
            Point p2 = order[1];
            Point p3 = order[2];
            Point p4 = order[3];

            bool b1 = IsRightAngle(p1, p3, p1, p2);
            bool b2 = IsRightAngle(p1, p3, p3, p4);
            bool b3 = IsRightAngle(p1, p4, p2, p3);
            return b1 && b2 && b3; ;
        }

        private static bool IsRightAngle(Point a1, Point a2, Point b1,Point b2)
        {
            int x1 = a1.x - a2.x;
            int x2 = a1.y - a2.y;

            int y1 = b1.x - b2.x;
            int y2 = b1.y - b2.y;

            return x1 * y1 + x2 * y2 == 0;
        }
    }
}
