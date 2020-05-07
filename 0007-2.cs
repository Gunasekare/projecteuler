//Problem - Euler Problem #7 (10001st prime)
//URL     - https://projecteuler.net/problem=7
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 2 with optimization 1(after obtaining the solution via v1)
//          ~9 sec improvement when calculating the 1000001 prime

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _0007
{
    class Program
    {
        static void Main(string[] args)
        {   
            const int findPrime = 10001;
            Console.WriteLine(PrimeGenerator(findPrime));
        }

        //Using a modified version of the FactorAndCheckPrime function used in #3
        //Generate the nth prime number using lookup table
        //Optimization 1 - all primes > 3 are of the for 6k +/- 1
        static int PrimeGenerator(int number)
        {
            List<int> primeFactorsList = new List<int>() { 2 };

            //At least 01 prime number
            if (number < 1)
                throw new ArgumentOutOfRangeException();

            //First prime number is a given value to avoid even numbers
            if (number == 1)
                return primeFactorsList[0];

            primeFactorsList.Add(3);

            //To enable optimization 1
            if (number == 2)
                return primeFactorsList[1];

            //Optimization 1:
            //Start from k = 1 (3rd prime) and build up to number via 6k +/- 1
            bool isPrime = true;

            for (int k = 1; primeFactorsList.Count < number; ++k)
            {   
                int n = 0;

                for (int s = -1; s <= 1 && primeFactorsList.Count < number; s += 2)
                {
                    n = 6 * k + s;
                    for (int value = 0; primeFactorsList[value] <= Math.Sqrt((double) n); ++value)
                        if (n % primeFactorsList[value] == 0)
                            isPrime = false;
                    
                    if (isPrime)
                        primeFactorsList.Add(n);
                    
                    isPrime = true;
                }                
            }

            return primeFactorsList[primeFactorsList.Count - 1];
        }
    }
}
