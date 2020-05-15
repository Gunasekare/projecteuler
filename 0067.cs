//Problem - Euler Problem #67 (Maximum path sum II)
//URL     - https://projecteuler.net/problem=67
//Author  - Gunasekare
//Date    - 2020-05-15
//Version - 1
//Des     - Using bottom-up approach in dynamic programming from #18


using System;
using System.IO;

namespace _0067
{
    class Program
    {   const int depth = 100;
        static void Main(string[] args)
        {
            int [][] grid = new int[depth][];
            
            using (StreamReader file = new StreamReader("0067-Data.txt"))
            {
                string line;
                int index = 0;

                while ((line = file.ReadLine()) != null)
                {   
                    string[] strArray = line.Split(" ");
                    grid[index] = new int[strArray.Length];

                    for (int i = 0; i < strArray.Length; ++i)
                        grid[index][i] = int.Parse(strArray[i]);

                    ++index;
                }
            }
            //Start from bottom - 1 line, compare the two values below and add the highest value
            //Work up
            for (int i = (depth - 2); i >= 0; --i)
                for (int j = 0; j < (i + 1); ++j)
                {
                    if (grid[i + 1][j] >= grid[i + 1][j + 1])
                        grid[i][j] += grid[i + 1][j];
                    else
                        grid[i][j] += grid[i + 1][j + 1];
                }
            
            Console.WriteLine(grid[0][0]);
        }
    }
}
