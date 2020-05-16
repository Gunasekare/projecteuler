//Problem - Euler Problem #24 (Lexicographic permutations)
//URL     - https://projecteuler.net/problem=24
//Author  - Gunasekare
//Date    - 2020-05-16
//Version - 1 (Naive)
//Des     - Using Heap's Algorithm https://en.wikipedia.org/wiki/Heap%27s_algorithm

using System;
using System.Collections.Generic;

namespace _0024
{
    class Program
    {
        const int index = 1000000;
        static List<string> allPermutations = new List<string>();
        static void Main(string[] args)
        {
            char[] objects = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Permute(objects.Length, objects);

            allPermutations.Sort();
            Console.WriteLine(allPermutations[index -1]);
        }

        static void Permute(int n, char[] objects)
        {
            char value;

            if (n == 1)
                allPermutations.Add(new string (objects));
            else 
                Permute(n - 1, objects);

            for (int i = 0; i < (n - 1); ++i)
            {
                if (n % 2 == 0)
                {
                    value = objects[i];
                    objects[i] = objects[n - 1];
                    objects[n - 1] = value;
                }
                else
                {
                    value = objects[0];
                    objects[0] = objects[n - 1];
                    objects[n - 1] = value;
                }

                Permute (n - 1, objects);
            }
        }
    }
}
