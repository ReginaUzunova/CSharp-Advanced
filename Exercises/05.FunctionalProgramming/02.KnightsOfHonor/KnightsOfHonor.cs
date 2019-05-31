using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = names => Console.WriteLine("Sir " + String.Join("\nSir ", names));

            print(input);
        }
    }
}
