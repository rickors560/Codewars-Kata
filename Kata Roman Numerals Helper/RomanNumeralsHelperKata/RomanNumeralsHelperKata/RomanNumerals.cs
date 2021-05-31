using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsHelperKata
{
    public class RomanNumerals
    {
        public static string ToRoman(int n)
        {
            string result = "";
            var RomanDict = new Dictionary<int, string>()
            {
                { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" },
                { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" },
                { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
            };


            while (n > 0)
            {
                if (RomanDict.ContainsKey(n))
                {
                    result += RomanDict[n];
                    n = 0;
                }
                else
                {
                    var nearestValue = RomanDict.Keys.ToList().First(o => o <= n);
                    result += RomanDict[nearestValue];
                    n -= nearestValue;
                }
            }

            return result;
        }

        public static int FromRoman(string romanNumeral)
        {
            int result = 0;

            var RomanDict = new Dictionary<string, int>()
            {
                { "M", 1000 }, { "CM", 900 }, { "D", 500 }, { "CD", 400 },
                { "C", 100 }, { "XC", 90 }, { "L", 50 }, { "XL", 40 },
                { "X", 10 }, { "IX", 9 }, { "V", 5 }, { "IV", 4 }, { "I", 1 }
            };

            if (RomanDict.ContainsKey(romanNumeral)) {
                return RomanDict[romanNumeral];
            }

            for(int i = 0; i < romanNumeral.Length -1; i++)
            {
                if (RomanDict.ContainsKey(romanNumeral.Substring(i, 2)))
                {
                    result += RomanDict[romanNumeral.Substring(i, 2)];
                    i++;
                }
                else {
                    result += RomanDict[romanNumeral[i].ToString()];
                }

                if(i == romanNumeral.Length - 2)
                { 
                    result += RomanDict[romanNumeral[i+1].ToString()];
                }
            }

            return result;
        }
    }
}
