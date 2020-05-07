//Problem - Euler Problem #20 (Factorial digit sum)
//URL     - https://projecteuler.net/problem=20
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 (Using an array to multiply individual digits
//          since result is too large for a ulong by recursion)

using System;

namespace _0020
{
    class Program
    {
        static void Main(string[] args)
        {
            const int factorialNumber = 100;
            int sum = 0;

            int[] factorialValue = Factorial(factorialNumber);
            Array.Reverse(factorialValue);

            foreach (int value in factorialValue)
                sum += value;
            
            Console.WriteLine(sum);
        }

        //Use old school multiplication
        //Multiply each digit by the next number with carry
        static int[] Factorial (int number)
        {
            //Initial size is 200 digits, but this could be adjusted
            //depending on number
            int[] digits = new int[200];

            //Initiate with 1, so that 1! = 1 
            digits[0] = 1;

            //Initiate with number of digits as 1
            int digitSize = 1;
            int product = 0;

            for (int i = 2; i <= number; i++)
            {   
                int carry = 0;

                //Multiply each digit in array by i, and add the carry 
                //until current number of digits is reached.
                //At the end, only the carry remains to be added 
                for (int index = 0; index < digitSize; ++index)
                {
                    product = (digits[index] * i) + carry;
                    digits[index] = product % 10;

                    carry = product / 10;
                }

                //Carry could have multiple digits since i is not a single digit
                //Populate carry value to new digit places according to size and
                //increment digitsize accordingly
                while (carry != 0)
                {
                    digits[digitSize] = carry % 10;
                    ++digitSize;
                    carry = carry / 10;
                }
            }

            return digits;
        }
    }
}
