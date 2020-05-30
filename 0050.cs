//Problem - Euler Problem #50 (Consecutive prime sum)
//URL     - https://projecteuler.net/problem=50
//Author  - Gunasekare
//Date    - 2020-05-30
//Version - 1 (Naive approach using a sliding window)
//Des     - Generating primes 00:00:00.0037302 : Sliding window 00:00:01.0095753

using System;
using System.Collections.Generic;
using System.Linq;

namespace _0050
{
    class Program
    {
        //prime should be below this value
        const int limit = 1000000;
        //minimum number of primes whose sum would be equal to limit
        const int nLimit = 4000;
        static void Main(string[] args)
        {
            PrimeNumbers prime = new PrimeNumbers();
            List<int> primeNumbers = prime.PrimesBelowEqN(nLimit);
            int sum;
            int i;
            int j;
            int maxLength = 0;
            int maxSum = 0;

            for (i = 0; (primeNumbers.Count - i) > maxLength; ++i)
            {
                sum = primeNumbers[i];
                for (j = (i + 1); j < primeNumbers.Count; ++j)
                {
                    sum += primeNumbers[j];

                    if (sum > limit)
                        break;
                    
                    if (prime.IsPrime(sum) && (maxLength < (j - i + 1)) && (sum < limit))
                    {
                        maxLength = j - i + 1;
                        maxSum = sum;

                        Console.WriteLine($"{maxLength} : {maxSum} : {primeNumbers[i]} : {primeNumbers[j]}");
                    }
                }
            }
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
            //Check whether the prime has already been calculated
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

        public List<int> PrimesBelowEqN(int number)
        {
            List<int> primes = new List<int>();

            foreach (int values in primeFactorsList)
            {
                if (values > number)
                    break;
                primes.Add(values);
            }

            if (primeFactorsList.Last() > number)
                return primes;

            int primeNumber = 0;
            //Calculate prime from the last calculated position onwards
            for (int i = (primeFactorsList.Count + 1); primeNumber <= number; ++i)
            {
                primeNumber = NthPrime(i);
                if (primeNumber <= number)
                    primes.Add(primeNumber);
            }

            return primes;
        }

        private List<int> primeFactorsList = new List<int>() { 2, 3 };
        private int k = 1;
    }
}
