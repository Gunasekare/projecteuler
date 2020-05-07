//Problem - Euler Problem #6 (Sum square difference)
//URL     - https://projecteuler.net/problem=6
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1

using System;

namespace _0006
{
    class Program
    {
        static void Main(string[] args)
        {
            const int number = 100;
            Console.WriteLine(SumSquare(number) - SquareSum(number));
        }

        static int SquareSum(int number)
        {
            if (number == 1)
                return 1;

            return (number * number) + SquareSum(--number);
        }

        static int SumSquare(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number; i++)
                sum += i;
            
            return sum * sum;
        }
    }
}
