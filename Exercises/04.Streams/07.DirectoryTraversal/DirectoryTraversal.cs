using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> directoryInfo = new Dictionary<string, Dictionary<string, decimal>>();

            string[] files = Directory.GetFiles("..//..//..//", "*.*", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);
                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var fileSize = Decimal.Divide(currentFile.Length, 1024);

                if (directoryInfo.ContainsKey(extension) == false)
                {
                    directoryInfo.Add(extension, new Dictionary<string, decimal>());
                }

                if (directoryInfo[extension].ContainsKey(fullName) == false)
                {
                    directoryInfo[extension].Add(fullName, fileSize);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (var item in directoryInfo.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
                {
                    streamWriter.WriteLine(item.Key);

                    foreach (var fileInfo in item.Value.OrderBy(x => x.Value))
                    {
                        streamWriter.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:F2}kb");
                    }
                }
            }
        }
    }
}
