//Problem - Euler Problem #19 (Counting Sundays)
//URL     - https://projecteuler.net/problem=19
//Author  - Gunasekare
//Date    - 2020-05-15
//Version - 1


using System;

namespace _0019
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int y = 1901; y <= 2000; ++y)
                for (int m = 1; m <= 12; ++m)
                {
                    DateTime date = new DateTime(y, m, 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                        ++sum;
                }
            
            Console.WriteLine(sum);
        }
    }
}
