using System;
using System.IO;


namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("..//..//..//..//files//text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("..//..//..//..//files//output.txt"))
                {
                    string line = streamReader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line {++counter}: {line}");

                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
