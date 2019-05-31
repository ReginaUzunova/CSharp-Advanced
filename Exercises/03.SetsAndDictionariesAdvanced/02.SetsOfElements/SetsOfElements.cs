using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                int firstSetNumber = int.Parse(Console.ReadLine());
                firstSet.Add(firstSetNumber);
            }

            for (int i = 0; i < input[1]; i++)
            {
                int secondSetNumber = int.Parse(Console.ReadLine());
                secondSet.Add(secondSetNumber);
            }

            foreach (var item in firstSet.Where(secondSet.Contains))
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
