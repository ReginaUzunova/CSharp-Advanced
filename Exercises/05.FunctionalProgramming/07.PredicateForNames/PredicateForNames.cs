using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> wantedNames = new List<string>();

            Func<string[], List<string>> func = names => names.Where(x => x.Length <= n).ToList();

            wantedNames = func(inputNames);

            foreach (var name in wantedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
