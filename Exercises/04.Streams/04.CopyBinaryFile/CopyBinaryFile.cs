using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream readFile = new FileStream("..//..//..//..//files//copyMe.png", FileMode.Open))
            {
                long size = readFile.Length;

                byte[] buffer = new byte[size];

                readFile.Read(buffer, 0, buffer.Length);

                using (FileStream writeFile = new FileStream("..//..//..//..//files//copyMe-copy.png", FileMode.Create))
                {
                    writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
