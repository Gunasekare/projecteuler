//Problem - Euler Problem #30 (Digit fifth powers)
//URL     - https://projecteuler.net/problem=30
//Author  - Gunasekare
//Date    - 2020-05-28
//Version - 1 (Naive)
//Des     - https://www.xarg.org/puzzle/project-euler/problem-30/

using System;

namespace _0030
{
    class Program
    {
        //Upper boundary of the calculation considering d x 9^5
        const int limit = 354294;
        static void Main(string[] args)
        {
            int[] digitPowers = new int[] {0,1,32,243,1024,3125,7776,16807,32768,59049};
            int sum;
            int sumDigitFifth = 0;

            for (int i = 10; i < limit; ++i)
            {
                sum = 0;
                string numeric = i.ToString();

                foreach (char value in numeric)
                    sum += digitPowers[int.Parse(value.ToString())];
                
                if (sum == i)
                    sumDigitFifth += i;
            }

            Console.Write (sumDigitFifth);
        }
    }
}
