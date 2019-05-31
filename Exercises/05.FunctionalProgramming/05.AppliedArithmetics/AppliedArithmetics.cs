using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int[], int[]> addFunc = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiplyFunc = nums => nums.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtractFunc = nums => nums.Select(x => x - 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums)); 

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = addFunc(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyFunc(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtractFunc(numbers);
                }
                else
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
