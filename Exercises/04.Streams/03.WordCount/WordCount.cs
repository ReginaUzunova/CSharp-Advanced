using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (StreamReader streamReader = new StreamReader("..//..//..//..//files//words.txt"))
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    if (words.ContainsKey(line) == false)
                    {
                        words.Add(line, 0);
                    }
                    
                    line = streamReader.ReadLine();
                }
            }

            using (StreamReader streamReader = new StreamReader("..//..//..//..//files//text.txt"))
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    Regex regex = new Regex("[a-zA-Z]+");

                    foreach (Match item in regex.Matches(line))
                    {
                        if (words.ContainsKey(item.Value))
                        {
                            words[item.Value] += 1;
                        }
                    }
                    
                    line = streamReader.ReadLine();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter("..//..//..//..//files//result.txt"))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
