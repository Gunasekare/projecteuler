//Problem - Euler Problem #8 (Largest product in a series)
//URL     - https://projecteuler.net/problem=08
//Author  - Gunasekare
//Date    - 2020-05-07
//Version - 1 (Sliding window approach)

using System;
using System.IO;

namespace _0008
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 1000;
            const int window = 13;
            byte[] dataFile = File.ReadAllBytes("0008-Data.txt");
            int[] values = new int[size];
            
            //Since the maximum value 9^13 is a large number
            ulong maxProduct = 0;

            //Convert byte array into an int array
            for (int i = 0; i < 1000; ++i)
                values[i] = (int) char.GetNumericValue((char) dataFile[i]);
            
            //sliding window
            for (int i = 0; i < (size - window); ++i)
            {
                ulong product = (ulong) values[i];
                //Iterate over each element in the window up to the max
                for (int j = (i + 1); j < (i + window); ++j)
                    product *= (ulong) values[j];
                
                if (product > maxProduct) 
                    maxProduct = product;
            }

            Console.WriteLine(maxProduct);
        }
    }
}
