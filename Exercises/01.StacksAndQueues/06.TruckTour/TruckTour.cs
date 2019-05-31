using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < number; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(input);
                
            }

            int index = 0;

            while (true)
            {
                int totalAmount = 0;

                foreach (var item in queue)
                {
                    int amount = item[0];
                    int distance = item[1];

                    totalAmount += amount - distance;

                    if (totalAmount < 0)
                    {
                        index++;
                        int[] pumpForRemove = queue.Dequeue();
                        queue.Enqueue(pumpForRemove);
                        break;
                    }
                }

                if (totalAmount >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
