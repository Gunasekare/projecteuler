//Problem - Euler Problem #14 (Longest Collatz sequence)
//URL     - https://projecteuler.net/problem=14
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 
//Using a function that I used for Exercism's problem on Collatz sequence
//Removed the global static steps counter and used pure recursion

using System;

namespace _0014
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            int limit = 1000000;
            uint[] maxSteps = new uint[] {0, 0};
            int stepValue = 0;
            for (uint number = 1; number < limit; ++number)
                if ((stepValue = Steps(number)) > maxSteps[1])
                {
                    maxSteps[1] = (uint) stepValue;
                    maxSteps[0] = number;
                }

            Console.WriteLine(maxSteps[0]);
            Console.WriteLine(maxSteps[1]);
        }

        public static int Steps(uint number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else if (number % 2 == 0)
            {
                return 1 + Steps(number / 2);
            }
            else
            {
                return 1 + Steps(3 * number + 1);
            }
        }
    }
}
