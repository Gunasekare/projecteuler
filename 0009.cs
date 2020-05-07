//Problem - Euler Problem #9 (Special Pythagorean triplet)
//URL     - https://projecteuler.net/problem=09
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 (Brute force)
//Math    - If m and n are two +tive numbers, m > n
//          a = m^2 - n^2
//          b = 2mn
//          c = m^2 + n^2

using System;

namespace _0009
{
    class Program
    {
        static void Main(string[] args)
        {   
            const int limit = 1000;
            int sum = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            bool flag = true;

            for (int m = 2; flag; m++)
                for (int n = 1; n < m; n++)
                {
                    a = (m * m) - (n * n);
                    b = 2 * m * n;
                    c = (m * m) + (n * n);

                    sum = a + b + c;

                    if (sum == limit)
                    {
                        flag = false;
                        break;
                    }
                }
            Console.WriteLine(a * b * c);
        }
    }
}
