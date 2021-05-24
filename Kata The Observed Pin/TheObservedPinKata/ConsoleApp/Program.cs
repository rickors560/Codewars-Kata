using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pins = GetPins("1357");
        }

        public static List<string> GetPins(string observed)
        {
            if (observed.Length < 1)
            {
                return null;
            }
            var combinations = new Dictionary<string, List<string>>() {
                { "1", new List<string>{ "1", "2", "4" } },
                { "2", new List<string>{ "1", "2", "3", "5" } },
                { "3", new List<string>{ "2", "3", "6"} },
                { "4", new List<string>{ "1", "4", "5", "7" } },
                { "5", new List<string>{ "2", "4", "5", "6", "8" } },
                { "6", new List<string>{ "3", "5", "6", "9" } },
                { "7", new List<string>{ "4", "7", "8" } },
                { "8", new List<string>{ "5", "7", "8", "9", "0" } },
                { "9", new List<string>{ "6", "8", "9" } },
                { "0", new List<string>{ "8", "0" } }
            };

            var res = new List<string>();
            res = combinations[observed[0].ToString()];
            if (observed.Length > 1)
            {
                res = combinations[observed[0].ToString()].SelectMany(n => combinations[observed[1].ToString()],
                    (a, b) => a + b).ToList();

                for (int i = 2; i < observed.Length; i++)
                {
                    int pos = i;
                    res = res.SelectMany(n => combinations[observed[i].ToString()], (a, b) => a + b).ToList();
                }
            }
            return res;
        }
    }
}