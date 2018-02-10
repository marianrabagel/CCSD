using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSD;

namespace ConsoleApplication2
{
    internal class testLZW
    {
        private bool inghetare;
        private UInt32 index;

        private List<string> symbolList = new List<string>(),
            decompressSymbolList = new List<string>();

        public testLZW()
        {
            inghetare = false;
            index = 9;

            for (int i = 0; i < 255; i++)
            {
                symbolList.Add(i.ToString());
                decompressSymbolList.Add(i.ToString());
            }
        }

        public testLZW(bool inghetare, UInt32 index)
        {
            if (index < 8 && index > 15)
                throw new Exception("Index value should be between 9 and 15");

            this.inghetare = inghetare;
            this.index = index;

            for (int i = 0; i < 255; i++)
            {
                symbolList.Add(i.ToString());
                decompressSymbolList.Add(i.ToString());
            }
        }

        public void Compress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = 8*(int) file.Length;
            int indexMaxSize = Convert.ToInt32(Math.Pow(2, index)) - 1;

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                //bitWriter.WriteBit(inghetare ? 1 : 0);
                //bitWriter.WriteNBits(index, 4);

                string s = "", ch = "";

                while (numberOfBits > 0)
                {
                    ch = Convert.ToString(bitReader.ReadNBit(8));
                    numberOfBits -= 8;
                    int firstOccurence = symbolList.IndexOf(s + ch);

                    if (firstOccurence != -1 && firstOccurence <= indexMaxSize)
                    {
                        s += ch;
                    }
                    else
                    {
                        Encode(s, bitWriter);

                        if (symbolList.Count > indexMaxSize)
                            if (inghetare)
                                continue;
                            else
                                symbolList.RemoveRange(256, indexMaxSize);

                        symbolList.Add(s + ch);
                        s = ch;
                    }
                }

                Encode(s, bitWriter);
            }
        }

        private void Encode(string s, BitWriter bitWriter)
        {
            bitWriter.Write(Convert.ToUInt32(symbolList.IndexOf(s)), (int)index);
        }

        public void Decompress(string inputFile, string outputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = 8*(int) file.Length;

            using (BitReader bitReader = new BitReader(inputFile))
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
               // bool tmpInghetare = bitReader.ReadBit() == 1;
             //   UInt32 tmpIndex = bitReader.ReadNBit(4);
                //int tmpIndexMaxSize = Convert.ToInt32(Math.Pow(2, tmpIndex)) - 1;
                string s = "";
                UInt32 chIndex;

                chIndex = bitReader.ReadNBit(index); ///nu index ci tmpIndex
                numberOfBits -= 8;
                s = decompressSymbolList[(int)chIndex];
                bitWriter.Write(Convert.ToUInt32(s), s.Length);

                while (numberOfBits > 0)
                {
                    chIndex = bitReader.ReadNBit(index);

                    if (chIndex < decompressSymbolList.Count)
                    {
                        string tmp = s;
                        s = decompressSymbolList[(int)chIndex];
                        tmp = tmp + s[0];
                        decompressSymbolList.Add(tmp); // inghetare sau golire
                    }
                    else
                    {
                        string tmp = s + s[0];
                        s = decompressSymbolList[(int)chIndex]; // inghetare sau golire
                    }

                    Write(s, bitWriter);
                    numberOfBits -= s.Length*8;
                }
            }
        }

        private void Write(string s, BitWriter bitWriter)
        {
            //throw new NotImplementedException();
        }
    }
}
