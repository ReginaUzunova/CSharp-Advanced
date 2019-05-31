using System;
using System.Linq;

namespace Problem03
{
    class Program
    {
        static string[][] jaggedArray;
        static long sRow;
        static long sCol;
        static long allCoalsSum;
        static long collectedCoals;
        static bool isDead;
        static bool isIgnore;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            jaggedArray = new string[rows][];

            GetJaggedArray();

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }

                if (isDead)
                {
                    break;
                }
                else if (collectedCoals == allCoalsSum)
                {
                    Console.WriteLine($"You collected all coals! ({sRow}, {sCol})");
                    break;
                }
                else if (isIgnore && i != commands.Length - 1)
                {
                    continue;
                }

                if (i == commands.Length - 1)
                {
                    Console.WriteLine($"{allCoalsSum - collectedCoals} coals left. ({sRow}, {sCol})");
                    break;
                }
            }
        }

        private static void Move(int row, int col)
        {
            long targetRow = sRow + row;
            long targetCol = sCol + col;

            if (IsInside(targetRow, targetCol))
            {
                if (jaggedArray[targetRow][targetCol] == "*")
                {
                    jaggedArray[targetRow][targetCol] = "s";
                    jaggedArray[sRow][sCol] = "*";
                    sRow = targetRow;
                    sCol = targetCol;
                }
                else if (jaggedArray[targetRow][targetCol] == "c")
                {
                    jaggedArray[targetRow][targetCol] = "s";
                    jaggedArray[sRow][sCol] = "*";
                    sRow = targetRow;
                    sCol = targetCol;
                    collectedCoals++;
                }
                else
                {
                    Console.WriteLine($"Game over! ({targetRow}, {targetCol})");
                    isDead = true;
                }
            }
            else
            {
                isIgnore = true;
            }
        }

        private static bool IsInside(long row, long col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }

        private static void GetJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split();

                if (jaggedArray[row].Contains("s"))
                {
                    sRow = row;
                    sCol = Array.IndexOf(jaggedArray[row], "s");
                }

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col].Contains("c"))
                    {
                        allCoalsSum++;
                    }
                }
            }
        }
    }
}
