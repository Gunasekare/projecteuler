//Problem - Euler Problem #48 (Self powers)
//URL     - https://projecteuler.net/problem=48
//Author  - Gunasekare
//Date    - 2020-05-20
//Version - 1 (Naive)
//Des     - I'm not too happy with this solution though.

using System;
using System.Numerics;

namespace _0048
{
    class Program
    {
	const int limit = 1000;
        static void Main(string[] args)
        {
            BigInteger sum = 0;

            for (int i = 1; i <= limit; ++i)
                sum += BigInteger.Pow(i, i);

            string value = sum.ToString();
            Console.Write(value.Substring(value.Length - 10));
            
        }
    }
}
