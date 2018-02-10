using System;
using System.IO;

namespace CCSD
{
    public class BitWriter : IDisposable
    {
        private byte buffer;
        private int writeCt;
        private BinaryWriter binaryWriter;
        private String fileName = "file.txt";
        /*
        public BitWriter()
        {
            if(File.Exists(fileName))
                File.Delete(fileName);

            binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create));
        }*/
        public BitWriter(string fileName, bool append = false)
        {
            if (!append)
                if (File.Exists(fileName))
                    File.Delete(fileName);

            binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate));
        }

        public void WriteBit(int bit)
        {
            buffer = (byte) ((bit << writeCt) | buffer);

            if (writeCt == 7)
            {
                binaryWriter.Write(buffer);
                writeCt = 0;
                buffer = 0;
                return;
            }

            writeCt++;
        }

        public void WriteNBits(int number, int ct)
        {
            if( ct > 32)
                throw new Exception("Numarul de biti scrisi trebuie sa fie mai mic de 32");
            
            for (int k = 0; k < ct; k++)
            {
                WriteBit(number%2);
                number = number >> 1;
            }
        }

        public void Dispose()
        {
            binaryWriter.Dispose();
        }
    }
}
