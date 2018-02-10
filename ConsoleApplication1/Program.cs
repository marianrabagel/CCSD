using System;
using System.IO;
using CCSD;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            string inputFile =
                "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\Blink 182 - Adam's Song.mp3";
            string outPutFile = "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\Blink 182 - Adam's Song_TTT.mp3";

            var fileSize = new FileInfo(inputFile).Length * 8;
            var random = new Random();

            using (var bitReader = new BitReader(inputFile))
            {
                using (var bitWriter = new BitWriter(outPutFile))
                {
                    do
                    {
                        long bitesRead = fileSize > 32 ? random.Next(32) : fileSize;

                        var value = bitReader.ReadNBit((uint)bitesRead);
                        bitWriter.Write(value, (int)bitesRead);

                        fileSize -= bitesRead;
                    } while (fileSize > 0);
                }
            }
        }
    }
}
