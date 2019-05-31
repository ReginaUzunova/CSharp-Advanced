using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedWater = 0;
            

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (bottles.Peek() >= cups[0])
                {
                    wastedWater += bottles.Pop() - cups[0];
                    cups.RemoveAt(0);
                   
                }
                else if (bottles.Peek() < cups[0])
                {
                    int reducedCup = 0;
                    reducedCup = cups[0] - bottles.Pop();
                    cups.RemoveAt(0);
                    cups.Insert(0, reducedCup);
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
