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
                   "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\file.txt",
                   outputFile =
                       "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\file_lzw_compressedB.txt";

            //testBitReaderAndBitWriter(inputFile, outputFile);

            //TestHuffman(inputFile, outputFile);

            //Lz77Coder lz77Coder = new Lz77Coder(5, 3);
            testLZW testLZW = new testLZW();
            testLZW.Compress(inputFile, outputFile);

            int positionExtensionStart = inputFile.IndexOf(".");
            string originalFileName = inputFile.Substring(0, positionExtensionStart),
                fileExtension = inputFile.Substring(positionExtensionStart);

            string fileName = originalFileName + "_decompressed" + fileExtension;

            testLZW.Decompress(outputFile, fileName);
        }
    }
}
