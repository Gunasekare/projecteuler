//Problem - Euler Problem #53 (Combinatoric selections)
//URL     - https://projecteuler.net/problem=53
//Author  - Gunasekare
//Date    - 2020-05-15
//Version - 1
//Des     - Using the modified form of Binomial Coefficient equation from #15


using System;

namespace _0053
{
    class Program
    {
        const int limit = 1000000;
        static void Main(string[] args)
        {
            int count = 0;

            for (int n = 1; n <=100; ++n)
                for (int k = 0; k <= n; ++k)
                    if (BinomCoefficient(n, k) > limit)
                        ++count;
            
            Console.WriteLine(count);
        }

        //The analytical formula for binomial coefficients is nCk = n!/(n - k)!k!
        //Since the grid is a perfect square n = 2k, so (2k)!/n!^2
        //But calculating factorials for 20! requires Big Integers
        //Using the following non-recursive formula provides O(n) performance
        //nCk =  i = 1 to k PRODUCT (n - k + i)/i
        static double BinomCoefficient(int n, int k)
        {
            double product = 1;
            for (int i = 1; i <= k; ++i)
                product *= (double) (n - k + i) / (double) i;

            return Math.Round(product);
        }
    }
}
