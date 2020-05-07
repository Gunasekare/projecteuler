//Problem - Euler Problem #14 (Longest Collatz sequence)
//URL     - https://projecteuler.net/problem=14
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 2 (using Memoization)

using System;
using System.Collections.Generic;

namespace _0014
{
    class Program
    {   
        static Dictionary<uint, int> cache = new Dictionary<uint, int>() {{1, 1}};
        static void Main(string[] args)
        {
            int limit = 1000000;
            uint[] maxSteps = new uint[] {0, 0};
            int stepValue = 0;

            for (uint number = 1; number < limit; ++number)
            {
                stepValue = Steps(number);

                if (!cache.ContainsKey(number))
                    cache.Add(number, stepValue);

                if (stepValue > maxSteps[1])
                {
                    maxSteps[1] = (uint) stepValue;
                    maxSteps[0] = number;
                }
            }

            Console.WriteLine(maxSteps[0]);
            Console.WriteLine(maxSteps[1]);
        }

        public static int Steps(uint number)
        {
            if (cache.TryGetValue(number,out int value))
                return value;
            if (number % 2 == 0)
                return 1 + Steps(number / 2);
            else
                return 1 + Steps(3 * number + 1);
        }
    }
}
