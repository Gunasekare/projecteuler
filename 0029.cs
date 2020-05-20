//Problem - Euler Problem #29 (Distinct powers)
//URL     - https://projecteuler.net/problem=29
//Author  - Gunasekare
//Date    - 2020-05-20
//Version - 1 (Naive)

using System;
using System.Collections.Generic;
using System.Numerics;

namespace _0029
{
    class Program
    {
        const int limit = 100;
        static void Main(string[] args)
        {
            List <string> terms = new List<string>();

            for (int a = 2; a <= limit; ++a)
                for (int b = 2; b <= limit; ++b)
                {
                    BigInteger number = BigInteger.Pow(a, b);

                    if (!terms.Contains(number.ToString()))
                        terms.Add(number.ToString());
                }

            Console.Write(terms.Count);
        }
    }
}
