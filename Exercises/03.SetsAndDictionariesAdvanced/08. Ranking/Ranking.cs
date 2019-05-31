using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> contestsPassword = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> students = new SortedDictionary<string, Dictionary<string, int>>();

            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string password = input[1];

                contestsPassword.Add(contest, password);

                input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            }

            string[] submissions = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (submissions[0] != "end of submissions")
            {
                string contest = submissions[0];
                string password = submissions[1];
                string studentName = submissions[2];
                int points = int.Parse(submissions[3]);

                if (contestsPassword.ContainsKey(contest) && contestsPassword[contest].Contains(password))
                {
                    if (students.ContainsKey(studentName) == false)
                    {
                        students.Add(studentName, new Dictionary<string, int>());
                    }

                    if (students[studentName].ContainsKey(contest) == false)
                    {
                        students[studentName].Add(contest, points);
                    }
                    else if (students[studentName][contest] < points)
                    {
                        students[studentName][contest] = points;
                    }
                    
                }

                submissions = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            var bestStudent = students.OrderByDescending(x => x.Value.Values.Sum()).Take(1);

            foreach (var kvp in bestStudent)
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            }

            Console.WriteLine("Ranking:");

            foreach (var name in students)
            {
                Console.WriteLine(name.Key);

                foreach (var item in name.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
                
            }
        }
    }
}
