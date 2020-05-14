//Problem - Euler Problem #12 (Highly divisible triangular number)
//URL     - https://projecteuler.net/problem=12
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 (Brute force) 
//Des	  - THIS DOES NOT WORK AND IS ONLY INCLUDED FOR
//	    PEDAGOGICAL REASONS

using System;
using System.Collections.Generic;

namespace _0012
{
    class Program
    {
        
        static void Main(string[] args)
        {   
            List <int> cache = new List<int>() {1};
            int limit = 500;

            for (int i = 2;; i++)
            {
                cache.Add(cache[i - 2] + i);
                if (Divisors(cache[i -1]) > limit)
                {
                    Console.WriteLine(cache[i -1]);
                    break;
                }
            }
        }

        static int Divisors(int number)
        {
            List <int> divisors = new List<int>();
            
            for (int i = 2; i <= number; i++)
                if (number % i == 0)
                    divisors.Add(i);
            
            return 1 + divisors.Count;
        }
    }
}
