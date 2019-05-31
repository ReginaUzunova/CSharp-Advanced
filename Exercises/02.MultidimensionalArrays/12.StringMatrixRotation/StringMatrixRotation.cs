using System;
using System.Collections.Generic;

namespace _12.StringMatrixRotation
{
    class StringMatrixRotation
    {
        //TODO
        static void Main(string[] args)
        {
            string[] rotatingInput = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string word = Console.ReadLine();

            Queue<string> queue = new Queue<string>();

            while (word != "END")
            {
                queue.Enqueue(word);
                word = Console.ReadLine();
            }

            int rows = queue.Count;

            char[][] jaggedArray = new char[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = queue.Dequeue().ToCharArray();
            }

            int degrees = int.Parse(rotatingInput[1]);

            if (degrees == 0 || degrees % 360 == 0)
            {
                Print(jaggedArray);
            }
            else if (degrees == 90)
            {
                Rotate90(jaggedArray, rows);
            }
        }

        private static void Rotate90(char[][] jaggedArray, int rows)
        {
            for (int col = 0; col < jaggedArray.Length - 1; col++)
            {
                for (int row = 0; row < jaggedArray[col].Length; row++)
                {

                }
            }
        }

        private static void Print(char[][] jaggedArray)
        {
            foreach (var item in jaggedArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}

