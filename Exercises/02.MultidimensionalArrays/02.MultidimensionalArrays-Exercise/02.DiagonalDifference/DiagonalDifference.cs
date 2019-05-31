using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[,] matrix = new int[input, input];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            int colForPrimary = 0;
            int colForSecondary = input - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalSum += matrix[row, colForPrimary];
                secondaryDiagonalSum += matrix[row, colForSecondary];
                colForPrimary++;
                colForSecondary--;
            }

            int differenceOfSums = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(differenceOfSums);
        }
    }
}
