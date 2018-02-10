using System;
using System.IO;

namespace CCSD
{
    class Program
    {
        public static void TestBitReaderAndBitWriter(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int nbr = 8 * (int)file.Length;
            Random randomNb = new Random();

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                while (nbr > 0)
                {
                    int nb = randomNb.Next(31) + 1;

                    if (nb > nbr)
                        nb = nbr;

                    int bitSequence = bitReader.readNBits(nb);
                    bitWriter.WriteNBits(bitSequence, nb);
                    nbr -= nb;
                }

                bitWriter.WriteNBits(0, 7);
            }
        }
        private static void Main(string[] args)
        {
            string inputFile =
                "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\file.txt";
            string outputFile =
                    "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\CCSD\\bin\\Debug\\file_LZ77_compressed.txt";
            
            //testBitReaderAndBitWriter(inputFile, outputFile);

            //TestHuffman(inputFile, outputFile);

            Lz77Coder lz77Coder = new Lz77Coder(5, 3);
            lz77Coder.Compress(inputFile, outputFile);
            /*
            int positionExtensionStart = inputFile.IndexOf(".");
            string originalFileName = inputFile.Substring(0, positionExtensionStart),
                fileExtension = inputFile.Substring(positionExtensionStart);

            string fileName = originalFileName + "_decompressed" + fileExtension;

            lz77Coder.Decompress(outputFile, fileName);
            */
            //TestLzw(inputFile, outputFile);
        }

        private static void TestLzw(string inputFile, string outputFile)
        {
            LzwCoder lzwCoder = new LzwCoder();
            lzwCoder.Compress(inputFile, outputFile);

            int positionExtensionStart = inputFile.IndexOf(".");
            string originalFileName = inputFile.Substring(0, positionExtensionStart),
                fileExtension = inputFile.Substring(positionExtensionStart);

            string fileName = originalFileName + "_decompressed" + fileExtension;

            lzwCoder.Decompress(outputFile, fileName);
        }

        private static void TestHuffman(string inputFile, string outputFile)
        {
            HuffmanCoder huffmanCoder = new HuffmanCoder();
            huffmanCoder.Compress(inputFile, outputFile);

            int positionExtensionStart = inputFile.IndexOf(".");
            string originalFileName = inputFile.Substring(0, positionExtensionStart),
                fileExtension = inputFile.Substring(positionExtensionStart);

            string fileName = originalFileName + "_decompressed" + fileExtension;

            huffmanCoder.Decompress(outputFile, fileName);
        }
    }
}

