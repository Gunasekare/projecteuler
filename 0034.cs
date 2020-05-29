//Problem - Euler Problem #34 (Digit factorials)
//URL     - https://projecteuler.net/problem=34
//Author  - Gunasekare
//Date    - 2020-05-29
//Version - 1 (Naive)
//Des     - https://www.xarg.org/puzzle/project-euler/problem-34/

using System;

namespace _0034
{
    class Program
    {
        //Upper boundary of the calculation considering d x 9!
        const int limit = 1499999;
        static void Main(string[] args)
        {
            int[] digitFactorials = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            int sum;
            int sumDigitFactorials = 0;

            for (int i = 10; i < limit; ++i)
            {
                sum = 0;
                string numeric = i.ToString();

                foreach (char value in numeric)
                    sum += digitFactorials[int.Parse(value.ToString())];

                if (sum == i)
                    sumDigitFactorials += i;
            }

            Console.Write(sumDigitFactorials);
        }
    }
}
