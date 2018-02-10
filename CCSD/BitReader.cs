using System;
using System.IO;

namespace CCSD
{
    public class BitReader : IDisposable
    {
        private byte buffer;
        private int readCt;
        private BinaryReader binaryReader;
        private string fileName = "file.txt";

        public BitReader()
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            
            binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
        }

        public BitReader(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
        }

        public byte readBit()
        {
            if (readCt%8 == 0)
                buffer = binaryReader.ReadByte();

            return (byte) ((buffer >> (readCt++ % 8)) % 2);
        }

        public int readNBits(int numberOfBits)
        {
            int result = 0;

            for (int k = 0; k < numberOfBits; k++)
                result = (readBit() << k) | result;

            return result;
        }

        public void Dispose()
        {
            binaryReader.Dispose();
        }
    }
}
