using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            int[] shotParameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, rows, cols, snake);

            int shotRow = shotParameters[0];
            int shotCol = shotParameters[1];
            int radius = shotParameters[2];

            Shooting(matrix, shotRow, shotCol, radius);

            Queue<char> elements = new Queue<char>(matrix.Length);

            MoveDown(matrix, elements);

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }

        private static void MoveDown(char[][] matrix, Queue<char> elements)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void Shooting(char[][] matrix, int shotRow, int shotCol, int radius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (Math.Pow(radius, 2) >= (Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2)))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void GetMatrix(char[][] matrix, int rows, int cols, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }

                        matrix[row][col] = snake[counter];
                        counter++;
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }

                        matrix[row][col] = snake[counter];
                        counter++;
                    }

                    isLeft = true;
                }
            }
        }
    }
}
