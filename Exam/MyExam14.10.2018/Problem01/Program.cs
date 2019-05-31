using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^s:([^;]+[\s]*);r:([^;]+[\s]*);m--(""[a-zA-Z\s]+"")$";
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (regex.IsMatch(input))
                {
                    string senderMatch = match.Groups[1].Value;
                    string receiverMatch = match.Groups[2].Value;
                    string messageMatch = match.Groups[3].Value;

                    string sender = "";
                    string receiver = "";

                    for (int j = 0; j < senderMatch.Length; j++)
                    {
                        if (char.IsLetter(senderMatch[j]) || char.IsWhiteSpace(senderMatch[j]))
                        {
                            sender += senderMatch[j];
                        }
                        else if (char.IsNumber(senderMatch[j]))
                        {
                            sum += int.Parse(senderMatch[j].ToString());
                        }
                    }

                    for (int j = 0; j < receiverMatch.Length; j++)
                    {
                        if (char.IsLetter(receiverMatch[j]) || char.IsWhiteSpace(receiverMatch[j]))
                        {
                            receiver += receiverMatch[j];
                        }
                        else if (char.IsNumber(receiverMatch[j]))
                        {

                            sum += int.Parse(receiverMatch[j].ToString());
                        }
                    }

                    Console.WriteLine($"{sender} says {messageMatch} to {receiver}");
                }
            }

            Console.WriteLine($"Total data transferred: {sum}MB");
        }
    }
}
