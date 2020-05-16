//Problem - Euler Problem #21 (Amicable numbers)
//URL     - https://projecteuler.net/problem=21
//Author  - Gunasekare
//Date    - 2020-05-16
//Version - 1

using System;
using System.Collections.Generic;

namespace _0021
{
    class Program
    {
        const int limit = 10000;
        static void Main(string[] args)
        {
            AmicableNumbers amicableNumbers = new AmicableNumbers();
            int sum = 0;

            foreach (int value in amicableNumbers.AmicableNumbersBelowN(limit))
                sum += value;
            
            Console.Write(sum);
        }

        public class AmicableNumbers
        {
            //Function to calculate the A259180 sequence to N
            public List<int> ToNthAmicableNumber(int number)
            {
                //If amicable numbers are already calculated, return
                if (number < amicableNumberList.Count)
                {
                    List<int> amicableNumbers = new List<int>();

                    for (int i = 0; i < number; ++i)
                        amicableNumbers.Add(amicableNumberList[i]);

                    return amicableNumbers;
                }

                if (number == amicableNumberList.Count)
                    return amicableNumberList;

                IntgerDivisors integerDivisors = new IntgerDivisors();

                //Start calculating amicable number. Sequence is set to 200 since the 
                //first amicable number starts from 220
                for (sequence = 200; amicableNumberList.Count < number; ++sequence)
                {
                    //If the sequence is already present, go to next
                    if (amicableNumberList.Contains(sequence))
                        continue;

                    //Calculate d(sequence) = a and d(a) = b
                    int a = integerDivisors.SumOfProperDivisors(sequence);
                    int b = integerDivisors.SumOfProperDivisors(a);

                    //Check if an amicable pair, add
                    if (sequence == b && sequence != a)
                    {
                        amicableNumberList.Add(sequence);
                        amicableNumberList.Add(a);
                    }
                }

                return amicableNumberList;

            }
            private List<int> amicableNumberList = new List<int>();
            private int sequence = 100;

            //Function to return A259180 sequence for a sequence value below n
            public List<int> AmicableNumbersBelowN(int number)
            {
                List<int> amicableNumbers = new List<int>();

                if (amicableNumberList.Count == 0)
                    for (int i = 1; ; ++i)
                    {
                        ToNthAmicableNumber(i);

                        if (amicableNumberList[amicableNumberList.Count - 1] > number)
                            break;
                    }

                else if (amicableNumberList[amicableNumberList.Count - 1] < number)
                    for (int i = amicableNumberList.Count; amicableNumberList[amicableNumberList.Count - 1] <= number; ++i)
                        ToNthAmicableNumber(i);

                for (int i = 0; amicableNumberList[i] <= number; ++i)
                    amicableNumbers.Add(amicableNumberList[i]);

                return amicableNumbers;
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
}
