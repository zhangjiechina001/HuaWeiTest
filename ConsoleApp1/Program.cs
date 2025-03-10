using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

class SrcData
{
    public int Total;
    public Dictionary<int, List<int>> StartEngineer = new Dictionary<int, List<int>>();
}

public class Program
{
    public static void Main()
    {
        SrcData src = GetSrc1();
        HashSet<int> lastStart = GetLastStart(src);

        Console.WriteLine($"{lastStart.Count} ");
        int[] arr = lastStart.ToArray();
        Console.WriteLine(string.Join(" ",arr));
        Console.ReadLine();
    }

    private static SrcData GetSrc1()
    {
        SrcData ret = new SrcData();
        string line1 = Console.ReadLine();

        string[] arr = line1.Split(' ');
        ret.Total = int.Parse(arr[0]);

        int startCount = int.Parse(arr[1]);

        for (int i = 0; i < startCount; i++)
        {
            int startIndex = int.Parse(arr[2+i*2]);
            int startPos = int.Parse(arr[3 + i * 2]);

            if (!ret.StartEngineer.ContainsKey(startIndex))
            {
                ret.StartEngineer[startIndex] = new List<int>();
            }

            ret.StartEngineer[startIndex].Add(startPos);
        }
        return ret;
    }

    private static SrcData GetSrc()
    {
        SrcData ret = new SrcData();
        string line1=Console.ReadLine();
        ret.Total = int.Parse(line1.Split(' ')[0]);

        int startCount= int.Parse(line1.Split(' ')[1]);

        for (int i = 0; i<startCount;i++)
        {
            string lineTemp = Console.ReadLine();
            int startIndex= int.Parse(lineTemp.Split(' ')[0]);
            int startPos = int.Parse(lineTemp.Split(' ')[1]);

            if(!ret.StartEngineer.ContainsKey(startIndex))
            {
                ret.StartEngineer[startIndex] = new List<int>();
            }

            ret.StartEngineer[startIndex].Add(startPos);
        }
        return ret;
    }



    private static HashSet<int> GetLastStart(SrcData src)
    {
        bool[] startEngine = new bool[src.Total];
        for (int i = 0;i<src.Total;i++)
        {
            HashSet<int> temp;
            if (src.StartEngineer.ContainsKey(i))
            {
                temp=StartOneTime(startEngine, src.StartEngineer[i]);
            }
            else
            {
                temp=StartOneTime(startEngine, new List<int>());
            }

            if (CheckAllStarted(startEngine))
            {
                return temp;
            }
        }

        return new HashSet<int>();
    }

    private static bool CheckAllStarted(bool[] startEngine)
    {
        foreach (bool i in startEngine)
        {
            if(!i)
            {
                return false;
            }
        }
        return true;
    }

    private static HashSet<int> StartOneTime(bool[] startEngine, List<int> startPos)
    {
        HashSet<int> ret = new HashSet<int>();
        bool[] startEngineCopy = startEngine.ToArray();
        for (int i = 0; i < startEngineCopy.Length; i++)
        {
            int prePos = i == 0 ? startEngineCopy.Length - 1 : i - 1;
            int nextPos = i == startEngineCopy.Length - 1 ? 0 : i + 1;
            if (startEngineCopy[i])
            {
                if(!startEngineCopy[prePos])
                {
                    ret.Add(prePos);
                }

                if(!startEngineCopy[nextPos])
                {
                    ret.Add(nextPos);
                }
                startEngine[prePos] = true;
                startEngine[nextPos] = true;
            }
        }

        foreach (int i in startPos)
        {
            if(!startEngine[i])
            {
                ret.Add(i);
            }
            startEngine[i] = true;
        }

        return ret;
    }
}