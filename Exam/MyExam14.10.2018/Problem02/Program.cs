using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "end")
            {
                if (input.Count() > 1)
                {
                    string name = input[0];
                    string tag = input[1];
                    int likes = int.Parse(input[2]);

                    if (users.ContainsKey(name) == false)
                    {
                        users.Add(name, new Dictionary<string, int>());
                    }

                    if (users[name].ContainsKey(tag) == false)
                    {
                        users[name].Add(tag, 0);
                    }

                    users[name][tag] = likes;
                }
                else
                {
                    string[] tokens = input[0].Split();
                    string userToBan = tokens[1];

                    if (users.ContainsKey(userToBan))
                    {
                        users.Remove(userToBan);
                    }

                }

                input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var user in users.OrderByDescending(u => u.Value.Values.Sum()).ThenBy(u => u.Value.Keys.Count()))
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
