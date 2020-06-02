//Problem - Euler Problem #42 (Coded triangle numbers)
//URL     - https://projecteuler.net/problem=42
//Author  - Gunasekare
//Date    - 2020-06-02
//Version - 1 (Naive)

using System;
using System.Collections.Generic;
using System.IO;

namespace _0042
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = new StreamReader("0042-DATA.txt"))
            {
                string line = file.ReadLine();
                string[] grid = line.Split(",");
                int sum;
                int totalTriangleWords = 0;

                foreach (string word in grid)
                {   
                    sum = 0;
                    foreach (char letter in word.Replace("\"", ""))
                        sum += letter - '@';

                    if (IsTriangleNumber(sum))
                        ++totalTriangleWords;
                }

                Console.Write (totalTriangleWords);
            }
        }
		
		//instead of using this function, can calculate the quadratic root to check whether the given number is triangular
        static List <int> triangleNumbers = new List<int>(){1};
        static bool IsTriangleNumber(int number)
        {            
            for (int i = triangleNumbers.Count + 1; triangleNumbers[triangleNumbers.Count - 1] <= number; ++i)
                triangleNumbers.Add((int)(0.5 * i * (i + 1)));

            if (triangleNumbers.Contains(number))
                return true;
            
            return false;
        }
    }
}
