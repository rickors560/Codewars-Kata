using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIntoSquaresKata
{
	public class Decompose
	{
        public static string decompose(long n)
        {
            var list = new List<long>();
            if (Divide(list, n * n, n))
                return string.Join(" ", list);

            return null;
        }

        private static bool Divide(List<long> numbers, double remain, long last)
        {
            if (remain <= 0)
                return remain == 0;

            for (var i = last - 1; i > 0; i--)
            {
                if (Divide(numbers, remain - (i * i), i))
                {
                    numbers.Add(i);
                    return true;
                }
            }
            return false;
        }
    }
}