//Problem - Euler Problem #2 (Even Fibonacci numbers)
//URL     - https://projecteuler.net/problem=2
//Author  - Gunasekare
//Date    - 2020-05-06
//Version - 1

using System;
using System.Collections.Generic;

namespace _0002
{
    class Program
    {
        // Generate Fibonacci Sequence up to the limit value using a lookup list
        // F(0) = 1
        // F(1) = 1
        // F(n) = F(n-1) + F(n-2)
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() {1, 1};
            int limit = 4000000;
            int sum = 0;

            for (int i = 2; sequence[i - 1] + sequence[i -2] <= limit; ++i)
            {
                sequence.Add(sequence[i - 1] + sequence[i -2]);

                //Check if an even term
                if (sequence[i] % 2 == 0)
                    sum += sequence[i];
            }
            Console.WriteLine(sum);
        }
    }
}
