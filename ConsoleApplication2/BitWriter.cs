using System;
using System.IO;

namespace CCSD
{
    public class BitWriter : IDisposable
    {
        private readonly BinaryWriter _outputFile;
        private byte _writeBuffer;
        private int _ctBitesWrite;

        public BitWriter(string outputFilePath)
        {
            _ctBitesWrite = 1;
            _outputFile = new BinaryWriter(new FileStream(outputFilePath, FileMode.Create));
        }

        public void Write(UInt32 value, int numberOfBits)
        {
            if (numberOfBits > 32)
            {
                throw new Exception("Numarul de biti care trebuie scris depaseste 32");
            }

            for (int k = numberOfBits - 1; k >= 0; k--)
            {
                WriteBit(value >> k);
            }
        }

        private void WriteBit(UInt32 value)
        {
            _writeBuffer <<= 1;
            _writeBuffer |= BitToBeWritten(value);

            if (_ctBitesWrite == 8)
            {
                _ctBitesWrite = 1;
                _outputFile.Write(_writeBuffer);
                _writeBuffer = 0;
            }
            else
            {
                _ctBitesWrite++;
            }
        }

        private static byte BitToBeWritten(uint value)
        {
            return (byte)(value % 2);
        }

        public void Dispose()
        {
            _outputFile.Dispose();
        }
    }
}
