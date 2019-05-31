using System;
using System.Linq;

namespace _07._LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalCells = 0;

            int[][] firstJaggedArray = new int[n][];
            int[][] secondJaggedArray = new int[n][];

            for (int row = 0; row < n; row++)
            {
                firstJaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                totalCells += firstJaggedArray[row].Length;
            }

            for (int row = 0; row < n; row++)
            {
                secondJaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .Select(int.Parse)
                    .ToArray();
                totalCells += secondJaggedArray[row].Length;
            }

            int colLength = firstJaggedArray[0].Length + secondJaggedArray[0].Length;

            bool isFit = true;

            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                if (firstJaggedArray[row].Length + secondJaggedArray[row].Length != colLength)
                {
                    isFit = false;
                    break;
                }
            }

            if (isFit)
            {
                for (int row = 0; row < firstJaggedArray.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstJaggedArray[row])}, {string.Join(", ", secondJaggedArray[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
