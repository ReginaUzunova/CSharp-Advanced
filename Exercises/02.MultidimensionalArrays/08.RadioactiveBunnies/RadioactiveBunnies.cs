using System;
using System.Linq;

namespace _08.RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];

            char[][] jaggedArray = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToArray();
            }

            string commandsInput = Console.ReadLine();
            bool isWin = false;
            bool isDead = false;
            int currentRow = 0;
            int currentCol = 0;

            while (!isWin && !isDead)
            {
                for (int i = 0; i < commandsInput.Length; i++)
                {
                    char command = commandsInput[i];

                    if (isWin || isDead)
                    {
                        break;
                    }

                    bool isFound = false;

                    for (int row = 0; row < jaggedArray.Length; row++)
                    {
                        if (isFound)
                        {
                            break;
                        }
                        for (int col = 0; col < jaggedArray[row].Length; col++)
                        {
                            if (jaggedArray[row][col] == 'P')
                            {
                                if (command == 'U')
                                {
                                    currentRow = row - 1;
                                    currentCol = col;

                                    if (IsInside(jaggedArray, row - 1, col) && jaggedArray[row - 1][col] == '.')
                                    {
                                        jaggedArray[row - 1][col] = 'P';
                                        jaggedArray[row][col] = '.';
                                        isFound = true;
                                        break;
                                    }
                                    else if (IsInside(jaggedArray, row - 1, col) && jaggedArray[row - 1][col] == 'B')
                                    {
                                        isDead = true;
                                        jaggedArray[row][col] = '.';
                                        break;
                                    }
                                    else
                                    {
                                        isWin = true;
                                        jaggedArray[row][col] = '.';
                                        currentRow = row;
                                        currentCol = col;
                                        break;
                                    }
                                }
                                else if (command == 'D')
                                {
                                    currentRow = row + 1;
                                    currentCol = col;

                                    if (IsInside(jaggedArray, row + 1, col) && jaggedArray[row + 1][col] == '.')
                                    {
                                        jaggedArray[row + 1][col] = 'P';
                                        jaggedArray[row][col] = '.';
                                        isFound = true;
                                        break;
                                    }
                                    else if (IsInside(jaggedArray, row + 1, col) && jaggedArray[row + 1][col] == 'B')
                                    {
                                        isDead = true;
                                        jaggedArray[row][col] = '.';
                                        break;
                                    }
                                    else
                                    {
                                        isWin = true;
                                        jaggedArray[row][col] = '.';
                                        currentRow = row;
                                        currentCol = col;
                                        break;
                                    }
                                }
                                else if (command == 'L')
                                {
                                    currentRow = row;
                                    currentCol = col - 1;

                                    if (IsInside(jaggedArray, row, col - 1) && jaggedArray[row][col - 1] == '.')
                                    {
                                        jaggedArray[row][col - 1] = 'P';
                                        jaggedArray[row][col] = '.';
                                        isFound = true;
                                        break;
                                    }
                                    else if (IsInside(jaggedArray, row, col - 1) && jaggedArray[row][col - 1] == 'B')
                                    {
                                        isDead = true;
                                        jaggedArray[row][col] = '.';
                                        break;
                                    }
                                    else
                                    {
                                        isWin = true;
                                        jaggedArray[row][col] = '.';
                                        currentRow = row;
                                        currentCol = col;
                                        break;
                                    }
                                }
                                else
                                {
                                    currentRow = row;
                                    currentCol = col + 1;

                                    if (IsInside(jaggedArray, row, col + 1) && jaggedArray[row][col + 1] == '.')
                                    {
                                        jaggedArray[row][col + 1] = 'P';
                                        jaggedArray[row][col] = '.';
                                        isFound = true;
                                        break;
                                    }
                                    else if (IsInside(jaggedArray, row, col + 1) && jaggedArray[row][col + 1] == 'B')
                                    {
                                        isDead = true;
                                        jaggedArray[row][col] = '.';
                                        break;
                                    }
                                    else
                                    {
                                        isWin = true;
                                        jaggedArray[row][col] = '.';
                                        currentRow = row;
                                        currentCol = col;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    for (int row = 0; row < jaggedArray.Length; row++)
                    {
                        for (int col = 0; col < jaggedArray[row].Length; col++)
                        {
                            if (jaggedArray[row][col] == 'B')
                            {
                                if (IsInside(jaggedArray, row, col + 1) && jaggedArray[row][col + 1] == '.')
                                {
                                    jaggedArray[row][col + 1] = 'X';
                                }
                                else if (IsInside(jaggedArray, row, col + 1) && jaggedArray[row][col + 1] == 'P')
                                {
                                    isDead = true;
                                    currentRow = row;
                                    currentCol = col + 1;
                                    jaggedArray[row][col + 1] = 'X';
                                }

                                if (IsInside(jaggedArray, row, col - 1) && jaggedArray[row][col - 1] == '.')
                                {
                                    jaggedArray[row][col - 1] = 'X';
                                }
                                else if (IsInside(jaggedArray, row, col - 1) && jaggedArray[row][col - 1] == 'P')
                                {
                                    isDead = true;
                                    currentRow = row;
                                    currentCol = col - 1;
                                    jaggedArray[row][col - 1] = 'X';
                                }

                                if (IsInside(jaggedArray, row + 1, col) && jaggedArray[row + 1][col] == '.')
                                {
                                    jaggedArray[row + 1][col] = 'X';
                                }
                                else if (IsInside(jaggedArray, row + 1, col) && jaggedArray[row + 1][col] == 'P')
                                {
                                    isDead = true;
                                    currentRow = row + 1;
                                    currentCol = col;
                                    jaggedArray[row + 1][col] = 'X';
                                }

                                if (IsInside(jaggedArray, row - 1, col) && jaggedArray[row - 1][col] == '.')
                                {
                                    jaggedArray[row - 1][col] = 'X';
                                }
                                else if (IsInside(jaggedArray, row - 1, col) && jaggedArray[row - 1][col] == 'P')
                                {
                                    isDead = true;
                                    currentRow = row - 1;
                                    currentCol = col;
                                    jaggedArray[row - 1][col] = 'X';
                                }
                            }
                        }
                    }

                    for (int row = 0; row < jaggedArray.Length; row++)
                    {
                        for (int col = 0; col < jaggedArray[row].Length; col++)
                        {
                            if (jaggedArray[row][col] == 'X')
                            {
                                jaggedArray[row][col] = 'B';
                            }
                        }
                    }
                }
            }

            if (isDead)
            {
                foreach (var item in jaggedArray)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"dead: {currentRow} {currentCol}");
            }
            else
            {
                foreach (var item in jaggedArray)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"won: {currentRow} {currentCol}");
            }
        }

        private static bool IsInside(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
    }
}
