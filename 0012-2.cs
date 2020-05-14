//Problem - Euler Problem #12 (Highly divisible triangular number)
//URL     - https://projecteuler.net/problem=12
//Author  - Gunasekare
//Date    - 2020-05-14
//Version - 2
//Dec     - Using prime numbers to generate number of divisors. Prime 
//          numbers generated using a modified method from #7.

using System;
using System.Collections.Generic;

namespace _0012
{
    class Program
    {
        const int limit = 500;
        static void Main(string[] args)
        {
            TriangularNumbers triangularNumber = new TriangularNumbers();
            IntgerDivisors divisors = new IntgerDivisors();
            
            int maxDivisors = 0;
            //change i to change the lower boundary of the lookup
            int i = 10000;

            while (maxDivisors <= limit)
            {
                ++i;
                maxDivisors = Math.Max (maxDivisors, divisors.NumberofDivisors(triangularNumber.GetTriangularNumber(i))); 
            }

            Console.WriteLine ($"{i} : {triangularNumber.GetTriangularNumber(i)}"); 
        }
    }

    public class TriangularNumbers
    {
        public int GetTriangularNumber(int number)
        {
            //If given triangular number index is absent, calculate
            //Triangular numbers can be calculated using  N(N+1)/2 where
            // n is the index, but I have used memoization to avoid
            //multiplication and division operations as this problem 
            //involves sequential number generation.
            if (cache.Count < number)
                for (int i = (cache.Count + 1); i <= number; ++i)
                    cache.Add(cache[i - 2] + i);

            return cache[number - 1];
        }

        private List<int> cache = new List<int>() { 1 };
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

        private List<int> primeFactorsList = new List<int>() { 2, 3};
        private int k = 1;
    }

    public class IntgerDivisors
    {
        //calculate the number of divisors in a number using prime numbers
        //if the factors of the number are p^a*q^b*r^c... where p,q and r are prime
        //number of divisors = (a+1)*(b+1)(c+1)....
        public int NumberofDivisors(int number)
        {
            List<int> divisors = new List<int>();
            PrimeNumbers prime = new PrimeNumbers();
            int divisorTotal = 1;
            int remainder = number;
            bool divisible;
            int primeNumber = 0;
            int divisorCount = 0;

            for (int i = 1; remainder != 1; ++i)
            {
                divisible = true;
                primeNumber = prime.NthPrime(i);
                divisorCount = 0;

               while(divisible)
                {
                    if (remainder % primeNumber == 0)
                    {
                        remainder /= primeNumber;
                        ++divisorCount;
                    }
                    else
                        divisible = false;
                }

                if (divisorCount != 0)
                    divisors.Add(divisorCount);
            }

            foreach (int value in divisors)
                divisorTotal *= (value + 1);

            return divisorTotal;
        }
    }

}
