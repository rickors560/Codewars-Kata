using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_consecutives
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = SumConsecutives(new List<int>() { 1, 4, 4, 4, 0, 4, 3, 3, 1 });
            r.ForEach(x => Console.WriteLine(x));
        }

        // A Better Aprroach with LINQ
        public static List<int> SumConsecutives(List<int> s)
        {
            var result =
                s.Select((element, index) => (element, index))
                .Where(x => x.index == 0 || x.element != s[x.index - 1])
                .Select(x => s.Skip(x.index).TakeWhile(z => (z == x.element)).Sum())
                .ToList();
            return result;
        }

        // Old Approach
        public static List<int> SumConsecutives1(List<int> s)
        {
            var arr = s.ToArray();
            List<int> res = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int c = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[i])
                    {
                        c++;
                    }
                    else
                    {
                        break;
                    }
                }
                res.Add(arr[i] * c);
                i += c - 1;
            }
            return res;
        }
    }
}