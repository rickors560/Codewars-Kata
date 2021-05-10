using System;

namespace Sum_of_products_and_LCMs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] test = new int[][] { new int[] { 15, 18 }, new int[] { 4, 5 }, new int[] { 12, 60 } };
            Console.WriteLine(SumDifferencesBetweenProductsAndLCMs(test));
        }
        public static int SumDifferencesBetweenProductsAndLCMs(int[][] pairs)
        {
            int result = 0;
            foreach (int[] pair in pairs) {
                int product = pair[0] * pair[1];
                int lcm = CalculateLCM(pair[0], pair[1]);
                result += product - lcm;
            }
            return result;
        }
        public static int CalculateLCM(int x, int y)
        {
            int num1 = Math.Max(x, y);
            int num2 = Math.Min(x, y);
            for (int i = 1; i < num2; i++)
            {
                int m = num1 * i;
                if (m % num2 == 0)
                {
                    return m;
                }
            }
            return num1 * num2;
        }
    }
}
