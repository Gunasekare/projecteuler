//Problem - Euler Problem #13 (Large sum)
//URL     - https://projecteuler.net/problem=13
//Author  - Gunasekare
//Date    - 2020-05-08
//Version - 1 (using the array technique developed in #20)
//Notes   - I have cleaned up the data file by removing the \r\n values to make it flat.         

using System;
using System.IO;

namespace _0013
{
    class Program
    {
        //Grid to hold the numbers to be summed.
        static int[,] dataValues = new int[100, 50];
        //Size of the resultant sum. Since 50 digits, maximum value is
        //(10^50 - 1) * 100 = 10^52 - 100. So 52 digits would be sufficient.
        const int size = 52;
        static int[] sum = new int[size];
        static void Main(string[] args)
        {

            //Read and store data in the grid.
            byte[] data = File.ReadAllBytes("0013-Data.txt");

            //Place value in row. Location is 50 * row number + column number.
            for (int i = 0; i < 100; ++i)
                for (int j = 0; j < 50; ++j)
                    dataValues[i, j] = (int)char.GetNumericValue((char)data[(50 * i) + j]);

            //Call summation function. This is to enable code reuse for another problem.
            LargeSum();
            
            Console.WriteLine(" ");
            for (int i = 0; i < 10; ++i)
                Console.Write(sum[i]);
        }

            static void LargeSum()
            {
                //Set initial value, 0 carry and digit position is rightmost of the sum array.
                int carry = 0;
                int digitPosition = size - 1;

                //Sum each value starting from rightmost digit and work down the rows.
                //I have used carry to calculate the sum right throughout.
                for (int i = 49; i >= 0; --i)
                {
                    for (int j = 0; j < 100; ++j)
                        carry += dataValues[j, i];

                    sum[digitPosition] = carry % 10;
                    --digitPosition;
                    carry /= 10;
                }

                //Complete remaining digits of the sum array with whatever remaining in carry.
                while (carry != 0)
                {
                    sum[digitPosition] = carry % 10;
                    --digitPosition;
                    carry /= 10;
                }
            }
    }
}
