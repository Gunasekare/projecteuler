//Problem - Euler Problem #25 (1000-digit Fibonacci number)
//URL     - https://projecteuler.net/problem=25
//Author  - Gunasekare
//Date    - 2020-05-10
//Version - 1
//Des     - Using a modified form of Binet's Formula to calculate Length of F(n)
//          without using brute-force approaches involving arrays or System.Numerics BigInteger.
//          URL - http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html

using System;

namespace _0025
{
    class Program
    {
        const int digits = 1000;
        static void Main(string[] args)
        {
            Console.WriteLine(FibonacciDigits(digits));
        }

        //Calculate the digits in a Fibonacci number using modified Binet's Formula and Log10
        static int FibonacciDigits(int size)
        {
            int result = 0;
            int number = 0;
            while (result < size)
            {
                //Binet's formula is Fib(n) = (Phi^n - (1/Phi)^n) / Sqrt(5)
                //where Phi = (Sqrt(5) + 1) / 2
                //but the (1/Phi)^n) can be discarded if n is large (as I have done here)
                //Number of digits of Fib(n) can be calculated using floor(Log10(Fib(n))) + 1
                //Implementing this as is results in an overflow somewhere around 308 digits 
                //which I suspect is due to C#'s limitations in handling intermediate results 
                //before assignment.
                //Simplifying the equation further resulted in the following, which worked
                //  floor((n * log10(Phi)) - (log10(5)/2)) + 1

                result = (int) Math.Floor((number * Math.Log10(((1 + Math.Sqrt(5))/2))) - Math.Log10(5)/2) + 1;
                ++number;
            }
            return number - 1;
        }
    }
}

