using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int enqueueElementsNumber = input[0];
            int dequeueElementsNumber = input[1];
            int searchingElement = input[2];

            int[] enqueueElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var num in enqueueElements)
            {
                queue.Enqueue(num);
            }

            for (int i = 0; i < dequeueElementsNumber; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchingElement))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
