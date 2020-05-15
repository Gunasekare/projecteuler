//Problem - Euler Problem #17 (Number letter counts)
//URL     - https://projecteuler.net/problem=17
//Author  - Gunasekare
//Date    - 2020-05-15
//Version - 1


using System;
using System.Collections.Generic;

namespace _0017
{
    class Program
    {   
        const int limit = 1000;
        static void Main(string[] args)
        {
            
            int sum = 0;
            for (int i = 1; i <= limit; ++i)
                sum += NumberLetterCount(i);
            
            Console.WriteLine(sum);
        }

        static int NumberLetterCount (int number)
        {
            //Construct a dictionary with name values
            Dictionary<int,int> countTable = new Dictionary<int, int>();
            countTable.Add(0, 0);
            countTable.Add(1, "one".ToCharArray().Length);
            countTable.Add(2, "two".ToCharArray().Length);
            countTable.Add(3, "three".ToCharArray().Length);
            countTable.Add(4, "four".ToCharArray().Length);
            countTable.Add(5, "five".ToCharArray().Length);
            countTable.Add(6, "six".ToCharArray().Length);
            countTable.Add(7, "seven".ToCharArray().Length);
            countTable.Add(8, "eight".ToCharArray().Length);
            countTable.Add(9, "nine".ToCharArray().Length);
            countTable.Add(10, "ten".ToCharArray().Length);
            countTable.Add(11, "eleven".ToCharArray().Length);
            countTable.Add(12, "twelve".ToCharArray().Length);
            countTable.Add(13, "thirteen".ToCharArray().Length);
            countTable.Add(14, "fourteen".ToCharArray().Length);
            countTable.Add(15, "fifteen".ToCharArray().Length);
            countTable.Add(16, "sixteen".ToCharArray().Length);
            countTable.Add(17, "seventeen".ToCharArray().Length);
            countTable.Add(18, "eighteen".ToCharArray().Length);
            countTable.Add(19, "nineteen".ToCharArray().Length);
            countTable.Add(20, "twenty".ToCharArray().Length);
            countTable.Add(30, "thirty".ToCharArray().Length);
            countTable.Add(40, "forty".ToCharArray().Length);
            countTable.Add(50, "fifty".ToCharArray().Length);
            countTable.Add(60, "sixty".ToCharArray().Length);
            countTable.Add(70, "seventy".ToCharArray().Length);
            countTable.Add(80, "eighty".ToCharArray().Length);
            countTable.Add(90, "ninety".ToCharArray().Length);

            //For digits less than 100
            if (number < 100)
            {
                //if numeral is below twenty or is divisible by 10
                if (number < 21 || number % 10 == 0)
                    return countTable[number];
                else
                    return countTable[number - (number % 10)] + countTable[number % 10];
            }
            else if (number > 99 && number < 1000)      //For digits greater than 99
            {
                if (number % 100 == 0)      //for hundreds
                    return countTable[number / 100] + "hundred".ToCharArray().Length;
                else if ((number % 100) < 21 || ((number % 100) % 10) == 0)     //if the 2nd and 3rd digits of the numeral is below twenty or is divisible by 10
                    return countTable[number / 100] + "hundredand".ToCharArray().Length + countTable[number % 100];
                else
                    return countTable[number / 100] + "hundredand".ToCharArray().Length + countTable[number - (number % 10) - ((number / 100) * 100)] + countTable[number % 10];
            }
            else
                return countTable[1] + "thousand".ToCharArray().Length;
        }
    }
}
