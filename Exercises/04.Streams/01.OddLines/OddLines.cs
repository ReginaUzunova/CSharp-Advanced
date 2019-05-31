using System;
using System.IO;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("..//..//..//..//files//text.txt"))
            {
                var line = streamReader.ReadLine();

                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;

                    line = streamReader.ReadLine();
                }
            }
        }
    }
}
