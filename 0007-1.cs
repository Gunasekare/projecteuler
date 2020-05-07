//Problem - Euler Problem #7 (10001st prime)
//URL     - https://projecteuler.net/problem=7
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1

using System;
using System.Collections.Generic;

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
        static int PrimeGenerator(int number)
        {
            List<int> primeFactorsList = new List<int>() { 2 };

            //At least 01 prime number
            if (number < 1)
                throw new ArgumentOutOfRangeException();

            //First prime number is a given value to avoid even numbers
            if (number == 1)
                return primeFactorsList[0];

            //Start from 3 (2nd prime) and build up to number
            //Generate odd numbers for optimization
            for (int i = 3; primeFactorsList.Count < number; i += 2)
            {
                bool isPrime = true;

                //Check whether stored primes upto Sqrt(i) divides i evenly
                //Only upto Sqrt(i) for optimization
                for (int value = 0; primeFactorsList[value] <= Math.Sqrt((double) i); ++value)
                    if (i % primeFactorsList[value] == 0)
                         isPrime = false;

                //if not divisible, prime
                if (isPrime)
                    primeFactorsList.Add(i);
            }

            return primeFactorsList[primeFactorsList.Count - 1];
        }
    }
}
