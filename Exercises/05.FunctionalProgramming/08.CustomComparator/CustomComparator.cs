using System;
using System.Linq;

namespace _08.CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] outputNumbers = new int[inputNumbers.Length];

            Func<int[], int[]> evenNumsFunc = nums => nums.Where(x => x % 2 == 0).ToArray();
            Func<int[], int[]> oddNumsFunc = nums => nums.Where(x => x % 2 != 0).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            outputNumbers = evenNumsFunc(inputNumbers);
            //Array.Sort(evenNumsFunc(outputNumbers));
            outputNumbers.Concat(oddNumsFunc(inputNumbers));
            print(outputNumbers);
        }
    }
}
