//Problem - Euler Problem #3 (Largest prime factor)
//URL     - https://projecteuler.net/problem=3
//Author  - Gunasekare
//Date    - 2020-05-06
//Version - 1

using System;
using System.Collections.Generic;

namespace _0003
{
    class Program
    {
        static void Main(string[] args)
        {   
            const ulong toBeFactored = 600851475143;
            List<ulong> primeFactorsList = FactorAndCheckPrime(toBeFactored);

            Console.WriteLine (primeFactorsList[primeFactorsList.Count - 1]);

        }

        //FactorAndCheckPrime - General function to find prime factors
        //Optimization 1      - Find factors up to the square root of a number
        //Optimization 2      - All prime numbers are odd
        //Description         - Starting from 3 to Sqrt(number) check whether each integer is
        //                      a divisor, if yes, check whether it is divisible by previously
        //                      discovered divisors and if divisible, not prime.
        static List<ulong> FactorAndCheckPrime(ulong number)
        {   
            List<ulong> primeFactorsList = new List<ulong>() {2};

            //No prime numbers below 2, 1 is niether prime nor composite
            if (number < 2)
                throw new ArgumentOutOfRangeException();
            
            //First prime number
            if (number == 2)
                return primeFactorsList;

            //From 3 to Sqrt(number) - optimization 1
            //Increment by 2 - optimization 2
            for (int i = 3; i < ((int)Math.Sqrt((double)number)); i += 2)
            {
                if (number % (ulong)i == 0)
                {
                    bool isPrime = true;

                    //check if divisible by previously discovered primes
                    foreach (int factor in primeFactorsList)
                        if (i % factor == 0)
                            isPrime = false;

                    if (isPrime)
                        primeFactorsList.Add((ulong)i);
                }
            }
            return primeFactorsList;
        }
    }
}
