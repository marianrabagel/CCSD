
using System;
using System.Collections.Generic;
using System.IO;

namespace CCSD
{
    public class LzwCoder
    {
        private bool _inghetare;
        private int _index;
        private List<string> _symbolList = new List<string>(),
            _decompressSymbolList = new List<string>();
        public LzwCoder()
        {
            _inghetare = true;
            _index = 9;

            for (int i = 0; i < 256; i++)
            {
                _symbolList.Add(((char) i).ToString());
                _decompressSymbolList.Add(((char) i).ToString());
            }
        }

        public LzwCoder(bool inghetare, int index)
        {
            if (index < 8 && index > 15)
                throw new Exception("Index value should be between 9 and 15");

            this._inghetare = inghetare;
            this._index = index;

            for (int i = 0; i < 256; i++)
            {
                _symbolList.Add(((char) i).ToString());
                _decompressSymbolList.Add(((char) i).ToString());
            }
        }


        public void Compress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = 8 * (int)file.Length;
            int indexMaxSize = Convert.ToInt32(Math.Pow(2, _index)) - 1;

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                bitWriter.WriteBit(_inghetare ? 1 : 0);
                bitWriter.WriteNBits(_index, 4);
                
                string s = "";
                char ch;

                while (numberOfBits > 0)
                {
                    ch = Convert.ToChar(bitReader.readNBits(8));
                    numberOfBits -= 8;
                    int firstOccurence = _symbolList.IndexOf(s + ch);

                    if (firstOccurence != -1 && firstOccurence <= indexMaxSize)
                    {
                        s += ch;
                    }
                    else
                    {
                        Encode(s, bitWriter);
                        
                        if (_symbolList.Count > indexMaxSize)
                        {
                            if (!_inghetare)
                            {
                                _symbolList.Clear();
                                for (int i = 0; i < 256; i++)
                                    _symbolList.Add(((char) i).ToString());
                            }
                        }
                    
                        _symbolList.Add(s + ch);
                        s = Convert.ToString(ch);
                    }
                }

                Encode(s, bitWriter);
                bitWriter.WriteNBits(0,7);
            }
        }

        private int GetIndex(string s)
        {
            return _symbolList.IndexOf(s.ToString());
        }

        private void Encode(string s, BitWriter bitWriter)
        {
            bitWriter.WriteNBits(_symbolList.IndexOf(s.ToString()), _index);
        }

        public void Decompress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = 8 * (int)file.Length;

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                bool inghetareD = bitReader.readNBits(1) == 1;
                int indexD = bitReader.readNBits(4);
                numberOfBits -= 5;

                string s = "";
                int indexMaxSize = Convert.ToInt32(Math.Pow(2, indexD)) - 1;
                int chIndex;
                chIndex = bitReader.readNBits(indexD);
                numberOfBits -= indexD;
                s = _decompressSymbolList[chIndex];
                bitWriter.WriteNBits(Convert.ToInt32(Convert.ToChar(s)), s.Length * 8);
                string entry = "";

                while (numberOfBits >= indexD)
                {
                    
                    chIndex = bitReader.readNBits(indexD);
                    numberOfBits -= indexD;
                    
                    if (chIndex >= _decompressSymbolList.Count)
                        entry = s + s[0];
                    else
                        entry = _decompressSymbolList[chIndex];

                    Write(entry, bitWriter);

                    if (_decompressSymbolList.Count > indexMaxSize)
                    {
                        if (!inghetareD)
                        {
                            _decompressSymbolList.Clear();
                            for (int i = 0; i < 256; i++)
                                _decompressSymbolList.Add(((char) i).ToString());
                        }
                    }
                 
                    _decompressSymbolList.Add(s + entry[0]);
                    s = entry;
                }
            }
        }

        private void Write(string s, BitWriter bitWriter)
        {
            for (int i = 0; i < s.Length; i++)
                bitWriter.WriteNBits(Convert.ToInt32(Convert.ToChar(s[i])), 8);
        }
    }
}
