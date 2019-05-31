using System;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));

            print(input);
        }
    }
}
