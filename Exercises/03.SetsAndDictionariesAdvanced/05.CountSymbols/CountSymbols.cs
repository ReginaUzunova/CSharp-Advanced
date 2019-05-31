using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (symbols.ContainsKey(input[i]) == false)
                {
                    symbols.Add(input[i], 0);
                }

                symbols[input[i]]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
