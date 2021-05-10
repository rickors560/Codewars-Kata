using System;

namespace Two_Joggers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NbrOfLaps(4, 6));
        }
        public static Tuple<int, int> NbrOfLaps(int x, int y)
        {
            int totalDistance = CalculateLCM(x, y);
            int Bobs_Laps = totalDistance / x;
            int Charles_Laps = totalDistance / y;
            return new Tuple<int, int>(Bobs_Laps, Charles_Laps);
        }
        public static int CalculateLCM(int x, int y) {
            int num1 = Math.Max(x, y);
            int num2 = Math.Min(x, y);
            for (int i = 1; i < num2; i++) {
                int m = num1 * i;
                if (m % num2 == 0) {
                    return m;
                }
            }
            return num1 * num2;
        }
    }
}