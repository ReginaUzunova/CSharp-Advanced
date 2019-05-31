using System;
using System.Collections.Generic;

namespace _08.StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < number - 1; i++)
            {
                long firstNumber = stack.Pop();
                long secondNumber = stack.Peek();
                stack.Push(firstNumber);
                stack.Push(firstNumber + secondNumber);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
