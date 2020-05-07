//Problem - Euler Problem #16 (Power digit sum)
//URL     - https://projecteuler.net/problem=19
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 (Using the digit multiplication technique in #20)

using System;

namespace _0016
{
    class Program
    {
        static void Main(string[] args)
        {
            const int power = 1000;
                int sum = 0;

            int[] powerValue = LargePowerOfTwo(power);
            Array.Reverse(powerValue);

            foreach (int value in powerValue)
                sum += value;
            
            Console.Write(sum);          
        }

        //Use old school multiplication
        //Multiply each digit by the next number with carry
        static int[] LargePowerOfTwo(int number)
        {
            //Initial size is 500 digits, but this could be adjusted
            //depending on number
            int[] digits = new int[500];

            //Initiate with 2, so that 2^1 = 2 
            digits[0] = 2;

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
                    product = (digits[index] * 2) + carry;
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
