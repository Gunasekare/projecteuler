//Problem - Euler Problem #40 (Champernowne's constant)
//URL     - https://projecteuler.net/problem=40
//Author  - Gunasekare
//Date    - 2020-05-30
//Version - 1 (brute force - execution time 00:02:54.4728350, could be optimized further)

using System;

namespace _0040
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "";

            for (int i = 1; value.Length < 1000000; ++i)
                value += i.ToString();

            Console.Write(int.Parse(value[0].ToString()) * int.Parse(value[9].ToString()) 
                                    * int.Parse(value[99].ToString()) * int.Parse(value[999].ToString())
                                    * int.Parse(value[9999].ToString()) * int.Parse(value[99999].ToString())
                                    * int.Parse(value[999999].ToString()));
        }
    }
}
