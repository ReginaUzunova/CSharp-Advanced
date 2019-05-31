using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int[], int[]> func = nums => nums.Where(x => x % n != 0).ToArray();

            numbers = func(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
