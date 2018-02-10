using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CCSD
{
    public class Lz77Coder
    {
        private int _searchBufferMaxLength, _lookAheadBufferMaxLength, _p, _l;
        private List<int> _slidingWindow;
        private byte[] buffer, bufferD;

        public Lz77Coder()
        {
            _searchBufferMaxLength = 3;
            _lookAheadBufferMaxLength = 5;
            _p = _l = 4;

            _slidingWindow = new List<int>(_searchBufferMaxLength + _lookAheadBufferMaxLength);
        }

        public Lz77Coder(int searchBufferMaxLength, int lookAheadBufferMaxLength)
        {
            if (searchBufferMaxLength < 5 || searchBufferMaxLength > 12)
                throw  new Exception("Search buffer value must be between 5 and 12");

            if (lookAheadBufferMaxLength < 3 || lookAheadBufferMaxLength > 6)
                throw new Exception("Look ahead buffer value must be between 3 and 6");
            
            _p = _l = 4;
            this._searchBufferMaxLength = searchBufferMaxLength;
            this._lookAheadBufferMaxLength = lookAheadBufferMaxLength;

            _slidingWindow = new List<int>(_searchBufferMaxLength + _lookAheadBufferMaxLength);
        }

        public void Compress2(string inputFile, string outputFile)
        {
            
            buffer = File.ReadAllBytes(inputFile);
            int index = 0;
            while (index<buffer.Length)
            {
                var searchBufffer = buffer.Take(index - 1);
                

                if (searchBufffer.Contains(buffer[index]))
                {
                    var lookBuffer = new List<byte>(buffer[index]);
                    index++;
                    while (SearchBufferContainsMyList(searchBufffer, lookBuffer))
                    {
                        lookBuffer.Add(buffer[index++]);
                    }
                }
                else
                {
                    Console.WriteLine("0,0,"+(char)buffer[index]);
                    index++;
                }
            }
           
        }

        private bool SearchBufferContainsMyList(IEnumerable<byte> searchBufffer, List<byte> lookBuffer)
        {
            var sir1 = new string(searchBufffer.Select( x => (char)x).ToArray());
            var sir2 = new string(lookBuffer.Select(x => (char)x).ToArray());

            return sir1.Contains(sir2);
        }


        public void Compress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            buffer = new byte[file.Length];
            int index = 0;
            
            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                FillBuffer(bitReader);

                int character = buffer[index];
                int position = 0;
                int length = 0;

                //first token
                WriteToken(bitWriter, position, length, character);
                _slidingWindow.Add(character);
                index++;

                character = buffer[index];
                length = 0;
                
                while (index < buffer.Length)
                {
                    int i = 0;
                    string prevChar = null;

                    while (i < _searchBufferMaxLength)
                    {
                        if (i < _slidingWindow.Count)
                            break;

                        int lookAheadIndex = index - i - 1;

                        if (buffer[lookAheadIndex] == character)
                        {
                            //vezi cat de lunga ii secventa de potrivire
                            prevChar = character.ToString();
                            int j = lookAheadIndex;

                            while (j < _lookAheadBufferMaxLength + i)
                            {
                                if (j > buffer.Length)
                                    break;

                                character = buffer[lookAheadIndex];

                            }
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                    
                /*******************************************************************************/
                //first token
                WriteToken(bitWriter, position, length, character);
                _slidingWindow.Add(character);

                character = bitReader.readNBits(8);
                position = 0;

                if (_slidingWindow[0] == character)
                {
                    length = 1;
                    _slidingWindow.Add(character);
                    character = bitReader.readNBits(8);
                }
                else
                    length = 0;
                
                //second token
                WriteToken(bitWriter, position, length, character);
                _slidingWindow.Add(character);

                character = bitReader.readNBits(8);

                if (_slidingWindow[1] == character)
                {
                    position = 0;
                    _slidingWindow.Add(character);
                    character = bitReader.readNBits(8);

                    if (_slidingWindow[2] == character)
                    {

                    }
                    else
                    {

                    }
                }
                else
                    if (_slidingWindow[0] == character)
                    {
                        position = 1;
                        _slidingWindow.Add(character);
                        character = bitReader.readNBits(8);

                        if (_slidingWindow[1] == character)
                        {
                            
                        }
                        else
                            length = 1;
                    }
                
                //third token
                WriteToken(bitWriter, position, length, character);
            }
            

        }

        private void WriteToken(BitWriter bitWriter, int position, int length, int character)
        {
            bitWriter.WriteNBits(position, _p);
            bitWriter.WriteNBits(length, _l);
            bitWriter.WriteNBits(character, 8);
        }

        private void FillBuffer(BitReader bitReader)
        {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Convert.ToByte(bitReader.readNBits(8));
        }


        public void Decompress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = (int) file.Length*8;

            bufferD = new byte[file.Length];

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                int searchbufferLength, lookAheadBufferlength;

                searchbufferLength = bitReader.readNBits(5);
                lookAheadBufferlength = bitReader.readNBits(3);

                int position, length, ch, indexD = 0;

                while (numberOfBits > 0)
                {
                    position = bitReader.readNBits(8);
                    length = bitReader.readNBits(8);
                    ch = bitReader.readNBits(8);
                    numberOfBits -= 24;
                    
                    if (length == 0)
                    {
                        bitWriter.WriteNBits(ch, 8);
                        bufferD[indexD++] = Convert.ToByte(ch);
                    }
                    else
                    {
                        for (int i = indexD - position - 1; i < length; i++)
                        {
                            bufferD[indexD++] = bufferD[i];
                            bitWriter.WriteNBits(bufferD[i], 8);
                        }

                        bufferD[indexD++] = Convert.ToByte(ch);
                        bitWriter.WriteNBits(ch, 8);
                    }

                }
            }
        }
    }
}
