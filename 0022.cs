//Problem - Euler Problem #22 (Names scores)
//URL     - https://projecteuler.net/problem=22
//Author  - Gunasekare
//Date    - 2020-05-16
//Version - 1

using System;
using System.Collections.Generic;
using System.IO;


namespace _0022
{
    class Program
    {
        const int limit = 10000;
        static void Main(string[] args)
        {
            Dictionary<char, int> letterValue = new Dictionary<char, int>();
            letterValue.Add('\"', 0);
            letterValue.Add('a', 1);
            letterValue.Add('b', 2);
            letterValue.Add('c', 3);
            letterValue.Add('d', 4);
            letterValue.Add('e', 5);
            letterValue.Add('f', 6);
            letterValue.Add('g', 7);
            letterValue.Add('h', 8);
            letterValue.Add('i', 9);
            letterValue.Add('j', 10);
            letterValue.Add('k', 11);
            letterValue.Add('l', 12);
            letterValue.Add('m', 13);
            letterValue.Add('n', 14);
            letterValue.Add('o', 15);
            letterValue.Add('p', 16);
            letterValue.Add('q', 17);
            letterValue.Add('r', 18);
            letterValue.Add('s', 19);
            letterValue.Add('t', 20);
            letterValue.Add('u', 21);
            letterValue.Add('v', 22);
            letterValue.Add('w', 23);
            letterValue.Add('x', 24);
            letterValue.Add('y', 25);
            letterValue.Add('z', 26);

            using (StreamReader file = new StreamReader("0022-Data.txt"))
            {
                int index = 1;
                int sum = 0;
                int totalSum = 0;
                string line = file.ReadLine();

                string[] grid = line.Split(",");
                Array.Sort(grid);

                foreach(string name in grid)
                {
                    sum = 0;
                    char[] nameArray = name.ToLower().ToCharArray();
                    foreach (char letter in nameArray)
                        sum += letterValue[letter];
                    
                    totalSum += index * sum;
                    ++index;
                }
                Console.WriteLine(totalSum);
            }
        }
    }
}
