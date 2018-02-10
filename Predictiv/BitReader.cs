using System;
using System.IO;
using System.Text;

namespace CCSD
{
    public class BitReader : IDisposable
    {
        private readonly BinaryReader _inputFile;
        private byte _readBuffer;
        private int _ctBitesRead = 8;

        public BitReader(string filepath)
        {
            _ctBitesRead = 8;

            _readBuffer = 0;

            _inputFile = new BinaryReader(File.Open(filepath, FileMode.Open), Encoding.UTF8);
        }

        public UInt32 ReadNBit(UInt32 n)
        {
            UInt32 result = 0;

            for (int i = 1; i <= n; i++)
            {
                result <<= 1;
                result = result | ReadBit();
            }

            return result;
        }

        private UInt32 ReadBit()
        {
            if (_ctBitesRead == 8)
            {

                _readBuffer = Convert.ToByte((_inputFile.ReadByte()));
                _ctBitesRead = 1;
            }
            else
            {
                _ctBitesRead++;
            }

            uint result = Convert.ToUInt32(_readBuffer < 128 ? 0 : 1);
            _readBuffer <<= 1;

            return result;

        }

        public void Dispose()
        {
            _inputFile.Dispose();
        }
    }


}
