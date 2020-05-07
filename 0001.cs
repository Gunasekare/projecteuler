//Problem - Euler Problem #1 (Multiples of 3 and 5)
//URL     - https://projecteuler.net/problem=1
//Author  - Gunasekare
//Date    - 2020-05-06
//Version - 1

using System;

namespace _0001
{
    class Program
    {
        static void Main(string[] args)
        {   
            const int number = 1000;
            int sum = multiples(number);
            Console.WriteLine(sum); 
        }

        static int multiples(int number)
        {
            int sum = 0;
            for (int i = 3; i < number; ++i)
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
                    
            return sum;
        }
    }
}
