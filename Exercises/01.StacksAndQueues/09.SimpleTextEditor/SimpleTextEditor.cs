using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
               
                switch (command)
                {
                    case "1":

                        string commandArgument = input[1];
                        stack.Push(text);

                        text += commandArgument;
                        break;

                    case "2":
                        int count = int.Parse(input[1]);
                        stack.Push(text);
                        text = text.Substring(0, text.Length - count);
                        break;

                    case "3":
                        int index = int.Parse(input[1]);
                        Console.WriteLine(text[index-1]);
                        break;

                    case "4":
                        text = stack.Pop();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
