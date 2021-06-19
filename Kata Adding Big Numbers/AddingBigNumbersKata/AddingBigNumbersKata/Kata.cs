using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AddingBigNumbersKata
{
    public class Kata
    {
        public static string Add(string a, string b)
        {
            var num1 = BigInteger.Parse(a);
            var num2 = BigInteger.Parse(b);

            var result = BigInteger.Add(num1, num2);
            return result.ToString();
        }
    }
}
