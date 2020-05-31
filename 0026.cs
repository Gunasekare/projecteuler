//Problem - Euler Problem #26 (Reciprocal cycles)
//URL     - https://projecteuler.net/problem=26
//Author  - Gunasekare
//Date    - 2020-05-31
//Version - 1 (Naive)

using System;
using System.Collections.Generic;
using System.Linq;

namespace _0026
{
    class Program
    {
        //d < 1000
        const int limit = 1000;
        static void Main(string[] args)
        {
            int maxCycle = 0;
            int maxD = 0;
            int maxPosition = 0;

            //start from 3 and work up. Ideally this should only be full reptend primes.
            for (int i = 3; i < limit; i += 2)
            {
                //divide 10 instead of 1 to avoid decimals altogether.
                int value = 10;
                int divisionsDone = 1;
                Dictionary<int, int> remainder = new Dictionary<int, int>() {{divisionsDone, 10}};

                //while a remainder is present
                while(value != 0)
                {
                    ++divisionsDone;
                    //calculate remainder
                    value = (value % i) * 10;

                    //if remainder exists, then cyclical. obtain length and update maximum values
                    if (remainder.ContainsValue(value))
                    {
                        int position = remainder.First(x => x.Value == value).Key;
                        if ((divisionsDone - position) > maxCycle)
                        {
                            maxCycle = divisionsDone - position;
                            maxD = i;
                            maxPosition = position;
                        }
                        break;
                    }
                    //else add remainder to list, repeat
                    remainder.Add(divisionsDone, value);
                }
            }
            
            Console.Write ($"Digit : {maxD}\tPosition : {maxPosition}\tCycle Length : {maxCycle}");
        }
    }
}
