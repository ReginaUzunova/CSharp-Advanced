using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '[' || current == '{' || current == '(')
                {
                    stack.Push(current);
                    continue;
                }
                if (stack.Count == 0)
                {
                    isValid = false;
                    Console.WriteLine("NO");
                    break;
                }
                if (current == ']')
                {
                    char last = stack.Peek();
                    if (last == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                }
                else if (current == '}')
                {
                    char last = stack.Peek();
                    if (last == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                }
                else if (current == ')')
                {
                    char last = stack.Peek();
                    if (last == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                }
            }

            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
