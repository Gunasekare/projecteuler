//Problem - Euler Problem #23 (Non-abundant sums)
//URL     - https://projecteuler.net/problem=23
//Author  - Gunasekare
//Date    - 2020-05-16
//Version - 1 (Naive)
//Des     - https://oeis.org/A048242 (Numbers that are not the sum of two abundant numbers)
//        - Sum of Non-Abundant Numbers = Sum of all numbers upto 20161 - sum of all numbers that are the sum of 02 abundant numbers

using System;
using System.Collections.Generic;

namespace _0023
{
    class Program
    {
        //Any number beyond 20161 can be expressed as a sum of two abundant numbers
        const int limit = 20161;
        static void Main(string[] args)
        {
            IntgerDivisors integer = new IntgerDivisors();
            List<int> abundantNumbers = new List<int>();
            List<int> sumOfAbundantNumbers = new List<int>();
            int totalNumberSum = 0;

            //Obtain abundant numbers upto limit, and calculate integer total from 1 to limit
            for (int i = 1; i <= limit; ++i)
            {
                totalNumberSum += i;

                if (integer.SumOfProperDivisors(i) > i)
                    abundantNumbers.Add(i);
            }

            //Calculate all possible numbers that are the sum of 02 abundant numbers
            //Reduce the number from the integer total calculated
            for (int i = 0; i < abundantNumbers.Count; ++i)
                for (int j = 0; j < abundantNumbers.Count; ++j)
                    if (abundantNumbers[i] + abundantNumbers[j] <= limit && !(sumOfAbundantNumbers.Contains(abundantNumbers[i] + abundantNumbers[j])))
                    {
                        sumOfAbundantNumbers.Add((abundantNumbers[i] + abundantNumbers[j]));
                        totalNumberSum -= (abundantNumbers[i] + abundantNumbers[j]);
                    }
            Console.Write(totalNumberSum);
        }
    }
    public class IntgerDivisors
    {
        public List<int> ProperDivisors(int number)
        {
            List<int> properDivisorsList;
            int sum = 1;

            if (number < 1)
                throw new ArgumentOutOfRangeException();

            if (properDivisorsListOfANumber.TryGetValue(number, out properDivisorsList))
                return properDivisorsList;

            properDivisorsList = new List<int>() { 1 };

            for (int i = 2; i <= Math.Sqrt(number); ++i)
            {
                if (number % i == 0)
                {
                    if (i == (number / i))
                    {
                        properDivisorsList.Add(i);
                        sum += i;
                    }
                    else
                    {
                        properDivisorsList.Add(i);
                        sum += i;
                        properDivisorsList.Add(number / i);
                        sum += (number / i);
                    }
                }
            }
            properDivisorsList.Sort();
            properDivisorsListOfANumber.Add(number, properDivisorsList);
            sumOfproperDivisorsOfANumber.Add(number, sum);
            return properDivisorsList;
        }
        private Dictionary<int, List<int>> properDivisorsListOfANumber = new Dictionary<int, List<int>>() { { 1, new List<int>() { 1 } } };
        private Dictionary<int, int> sumOfproperDivisorsOfANumber = new Dictionary<int, int>() { { 1, 1 } };

        public int SumOfProperDivisors(int number)
        {
            if (sumOfproperDivisorsOfANumber.TryGetValue(number, out int sum))
                return sum;

            ProperDivisors(number);
            return sumOfproperDivisorsOfANumber[number];
        }
    }
}
