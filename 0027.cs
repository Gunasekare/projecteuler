//Problem - Euler Problem #27 (Quadratic primes)
//URL     - https://projecteuler.net/problem=27
//Author  - Gunasekare
//Date    - 2020-05-29
//Version - 1 (Naive)

using System;
using System.Collections.Generic;

namespace _0027
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumbers prime = new PrimeNumbers();

            int maxN = 0;
            int maxA = 0;
            int maxB = 0;

            for (int a = -999; a < 1000; ++a)
                for (int b = -1000; b <= 1000; ++b)
                {
                    bool primeFlag = true;
                    for (int n = 0; primeFlag; ++n)
                    {
                        int value = (int)Math.Pow(n, 2) + (a * n) + b;
                        primeFlag = prime.IsPrime(value);

                        if (!primeFlag && (n > maxN))
                        {
                            maxN = n;
                            maxA = a;
                            maxB = b;
                        }

                    }
                }
            Console.Write($"{maxN}\t{maxA}\t{maxB} : {maxA * maxB}");
        }
    }

    public class PrimeNumbers
    {
        public int NthPrime(int number)
        {
            //At least 01 prime number
            if (number < 1)
                throw new ArgumentOutOfRangeException();

            //First prime number is a given value to avoid even numbers
            if (number == 1)
                return primeFactorsList[0];

            //To enable optimization 1
            if (number == 2)
                return primeFactorsList[1];

            //Optimization 1:
            //Start from k = 1 (3rd prime) and build up to number via 6k +/- 1
            //k is a property to permit multiple invocations of the object
            bool isPrime = true;

            for (; primeFactorsList.Count < number; ++k)
            {
                int n = 0;

                for (int s = -1; s <= 1; s += 2)
                {
                    n = 6 * k + s;
                    for (int value = 0; primeFactorsList[value] <= Math.Sqrt((double)n); ++value)
                        if (n % primeFactorsList[value] == 0)
                            isPrime = false;

                    if (isPrime)
                        primeFactorsList.Add(n);

                    isPrime = true;
                }
            }
            //both 6k + 1 and 6k - 1 can be primes. Discarding one because the
            //limit was reached will prevent the other from being discovered during the
            //subsequent invocation. Hence add to list and return the correct prime.
            if (primeFactorsList.Count == number)
                return primeFactorsList[primeFactorsList.Count - 1];

            return primeFactorsList[primeFactorsList.Count - 2];
        }

        public bool IsPrime(int number)
        {
            //Check whether the prime has been already calculated
            if (primeFactorsList.Contains(number))
                return true;
            else if (primeFactorsList[primeFactorsList.Count - 1] > number)
                return false;

            int primeNumber = 0;
            //Calculate prime from the last calculated position onwards
            for (int i = (primeFactorsList.Count + 1); primeNumber < number; ++i)
                primeNumber = NthPrime(i);

            if (primeFactorsList.Contains(number))
                return true;

            return false;
        }

        private List<int> primeFactorsList = new List<int>() { 2, 3 };
        private int k = 1;
    }
}
