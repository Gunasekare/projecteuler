//Problem - Euler Problem #4 (Largest palindrome product)
//URL     - https://projecteuler.net/problem=04
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1

using System;

namespace _0004
{
    class Program
    {
        static void Main(string[] args)
        {
            int palindrome = 0;
            string palindromeArray = " ";
            int maxPalin = 0;
            const int upperBound = 999;
            const int lowerBound = 99;

            //calculate product of 2 numbers in descending order
            // to improve chances of finding the largest palindrome first
            for (int i = upperBound; i > lowerBound; i--)
                for (int j = i; j > lowerBound; j--)
                {
                    palindrome = i * j;
                    
                    //This improvement was added after solving
                    //Skip i,j if product is smaller than maximum known palindrome
                    if (palindrome < maxPalin)
                        break;
                    palindromeArray = palindrome.ToString();
                    
                    //Convert product into a string array and check if palindrome
                    bool palinFlag = true;
                    for (int k = 0; k < palindromeArray.Length; k++)
                        if (palindromeArray[palindromeArray.Length - 1 - k] != palindromeArray[k])
                            palinFlag = false;

                    //If a palindrome, check if it is the largest
                    if (palinFlag && palindrome > maxPalin)
                        maxPalin = palindrome;
                }
            
            Console.WriteLine(maxPalin);
        }
    }
}
