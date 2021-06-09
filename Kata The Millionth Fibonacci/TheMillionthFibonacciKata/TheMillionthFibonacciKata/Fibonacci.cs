using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TheMillionthFibonacciKata
{
    public class Fibonacci
    {
        //Both are dynamic programming approach
        public static BigInteger fib(int n)
        {
            //https://www.youtube.com/watch?v=EEb6JP3NXBI

            if (n == 0) return BigInteger.Zero;

            var mat = new BigInteger[,]
            {
               { 1, 1 },
               { 1, 0 }
            };

            var result = power(mat, Math.Abs(n) - 1);

            var fn = result[0, 0];

            if (n < 0 && n % 2 == 0)
            {
                fn = -fn;
            }

            return fn;
        }

        private static BigInteger[,] power(BigInteger[,] m, int n)
        {
            //Initial value of m;
            BigInteger[,] mat = { 
                { 1, 1 }, 
                { 1, 0 }
            };

            if (n == 1 || n == 0) return mat;

            //As arrays are reference types by default so we dont need to update m after every recursion 
            //It will be updated automatically
            power(m, n / 2);

            BigInteger[,] temp = {
                {m[0,0],m[0,1]},
                {m[1,0],m[1,1]}
            };

            // m = m*m

            m[0, 0] = temp[0, 0] * temp[0, 0] + temp[0, 1] * temp[1, 0];
            m[0, 1] = temp[0, 0] * temp[0, 1] + temp[0, 1] * temp[1, 1];
            m[1, 0] = temp[1, 0] * temp[0, 0] + temp[1, 1] * temp[1, 0];
            m[1, 1] = temp[1, 0] * temp[0, 1] + temp[1, 1] * temp[1, 1];

            if (n % 2 == 1)
            {
                BigInteger[,] temp2 = {
                    {m[0,0],m[0,1]},
                    {m[1,0],m[1,1]}
                };

                //m = m*(initial m value that is in mat)

                m[0, 0] = temp2[0, 0] * mat[0, 0] + temp2[0, 1] * mat[1, 0];
                m[0, 1] = temp2[0, 0] * mat[0, 1] + temp2[0, 1] * mat[1, 1];
                m[1, 0] = temp2[1, 0] * mat[0, 0] + temp2[1, 1] * mat[1, 0];
                m[1, 1] = temp2[1, 0] * mat[0, 1] + temp2[1, 1] * mat[1, 1];
            }

            return m;
        }




        public static BigInteger fib1(int n)
        {
            //https://www.geeksforgeeks.org/program-for-nth-fibonacci-number/ method 6

            if (n == 0) 
            {
                return 0;
            }
            if (n == 1) 
            {
                return 1;
            }

            if (n < 0) 
            {
                if (n % 2 == 0)
                {
                    return -fib(-n);
                }
                else 
                {
                    return fib(-n);
                }
            }

            int k = n/2;
            if (n % 2 != 0)
            {
                k = (n + 1) / 2;

                var x = fib(k);
                var y = fib(k - 1);

                return (x * x) + (y * y); 
            }

            var a = fib(k);
            var b = fib(k - 1);
            return ((2 * b) + a) * a;
        }
    }
}