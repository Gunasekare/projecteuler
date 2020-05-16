//Problem - Euler Problem #28 (Number spiral diagonals)
//URL     - https://projecteuler.net/problem=28
//Author  - Gunasekare
//Date    - 2020-05-16
//Version - 1
//Dec     - Diag 1 is A016754 = (2*n+1)^2
//          Diag 2 is A054554 = 4*n^2 - 10*n + 7
//          Diag 3 is A053755 = 4*n^2 + 1
//          Diag 4 is A054569 = 4*n^2 - 6*n + 3

using System;

namespace _0028
{
    class Program
    {
        const int limit = 1001;
        static void Main(string[] args)
        {
            int sum = 1;
            for (int i = 2; i <= (((limit - 1) / 2) + 1); ++i)
            {
                int suma = (((2 * (i - 1)) + 1) * ((2 * (i - 1)) + 1));
                int sumb = ((4 * i * i) - (10 * i) + 7);
                int sumc = ((4 * (i - 1) * (i - 1)) + 1);
                int sumd = ((4 * i * i) - (6 * i) + 3);

                sum += suma + sumb + sumc + sumd;
            }
            
            Console.Write(sum);

        }
    }
}
