//Problem - Euler Problem #36 (Double-base palindromes)
//URL     - https://projecteuler.net/problem=36
//Author  - Gunasekare
//Date    - 2020-05-19
//Version - 1 (Naive)

using System;

namespace _0036
{
    class Program
    {
        const int limit = 1000000;
        static void Main(string[] args)
        {
            int sum = 0;

            for (int number = 0; number < limit; ++number)
            {
                bool decimalFlag = false;

                char[] numberPalindrome = number.ToString().ToCharArray();
                Array.Reverse(numberPalindrome);

                bool firstDigit = true;
                for (int i = 0; i < numberPalindrome.Length && firstDigit == true; ++i)
                {
                    if (numberPalindrome[i] != '0')
                    {
                        firstDigit = false;
                        break;
                    }
                    else
                        numberPalindrome[i] = ' ';
                }

                if (new string(numberPalindrome).Replace(" ", "") == number.ToString())
                    decimalFlag = true;

                char[] binary = Convert.ToString(number, 2).ToCharArray();
                Array.Reverse(binary);

                firstDigit = true;
                for (int i = 0; i < binary.Length && firstDigit == true; ++i)
                {
                    if (binary[i] == '1')
                    {
                        firstDigit = false;
                        break;
                    }
                    else
                        binary[i] = ' ';
                }

                if ((new string(binary).Replace(" ", "") == Convert.ToString(number, 2)) && decimalFlag)
                        sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
