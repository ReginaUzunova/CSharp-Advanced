using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split();
                string vloggerName = tokens[0];
                string command = tokens[1];
                string followName = tokens[2];

                if (command == "joined")
                {
                    if (vloggers.ContainsKey(vloggerName) == false)
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        vloggers[vloggerName].Add("following", new SortedSet<string>());
                        vloggers[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    bool isSamePerson = vloggerName == followName;

                    if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followName) && !isSamePerson)
                    {
                        vloggers[vloggerName]["following"].Add(followName);
                        vloggers[followName]["followers"].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int counter = 1;

            foreach (var item in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var name in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }

                counter++;
            }
        }
    }
}
