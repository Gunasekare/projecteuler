//Problem - Euler Problem #15 (Lattice paths)
//URL     - https://projecteuler.net/problem=15
//Author  - Gunasekare
//Date    - 2020-05-11
//Version - 1
//Des     - Using a modified form of Binomial Coefficient equation to solve the problem
//          URL - https://www.robertdickau.com/lattices.html
//              - https://cp-algorithms.com/combinatorics/binomial-coefficients.html

using System;

namespace _0015
{
    class Program
    {
        //For a 20 x 20 grid
        const int grid = 20;
        static void Main(string[] args)
        {
            Console.WriteLine(BinomCoefficient((2 * grid), grid));
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
