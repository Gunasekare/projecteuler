//Problem - Euler Problem #31 (Coin sums)
//URL     - https://projecteuler.net/problem=31
//Author  - Gunasekare
//Date    - 2020-05-31
//Version - 1

using System;

namespace _0031
{
    class Program
    {
        const int value = 200;
        static void Main(string[] args)
        {
            int[] coins = new int[] {1, 2, 5, 10, 20, 50, 100, 200};
            int[] combinations = new int[value + 1];

            combinations[0] = 1;

            for (int i = 0; i < coins.Length; ++i)
                for (int j = 0; j < combinations.Length; ++j)
                    if (coins[i] <= j)
                        combinations[j] += combinations[j - coins[i]];

            Console.Write(combinations[value]);
        }
    }
}
