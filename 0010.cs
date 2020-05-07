//Problem - Euler Problem #10 (Summation of primes)
//URL     - https://projecteuler.net/problem=10
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 

using System;
using System.Collections.Generic;

namespace _0010
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 2000000;
            Console.WriteLine(PrimeGenerator(limit));
        }

        //Modification of PrimeGenrator function from #7-2
        //Number represents prime value limit
        static ulong PrimeGenerator(int number)
        {
            List<int> primeFactorsList = new List<int>() { 2 };
            ulong sumOfPrimes = 5;

            //No primes less than 2
            if (number <= 2)
                throw new ArgumentOutOfRangeException();

            //Minimum prime sum is 2 and next is 5
            if (number < 5)
                return 2;

            //To enable optimization 1
            primeFactorsList.Add(3);

            //Optimization 1:
            //Start from k = 1 (3rd prime) and build up to number via 6k +/- 1
            bool isPrime = true;
            bool limit = true;

            //Loop until limit is breached
            for (int k = 1; limit; ++k)
            {   
                int n = 0;

                for (int s = -1; s <= 1 && primeFactorsList.Count < number; s += 2)
                {
                    n = 6 * k + s;
                    for (int value = 0; primeFactorsList[value] <= Math.Sqrt((double) n); ++value)
                        if (n % primeFactorsList[value] == 0)
                            isPrime = false;
                    
                    //Sum if prime and less than limit
                    if (isPrime && n < number)
                    {
                        primeFactorsList.Add(n);
                        sumOfPrimes = sumOfPrimes + (ulong) n;
                    }
                    else if (isPrime && n >= number)
                    {
                        limit = false;
                        break;
                    }
                    
                    isPrime = true;
                }                
            }

            return sumOfPrimes;
        }
    }
}
