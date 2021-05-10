using System;
using System.Collections.Generic;
using System.Linq;

namespace Delete_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] r = DeleteNth(new int[] { 1, 2, 3, 1, 2, 3, 5, 1 }, 1);
            r.ToList().ForEach(x => Console.WriteLine(x));
        }
        public static int[] DeleteNth(int[] arr, int x)
        {
            List<int> result = new List<int>();
            foreach (int i in arr) {
                if (result.Count(item => item == i) < x)
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
    }
}
