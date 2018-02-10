using System;
using System.Collections.Generic;
using System.IO;

namespace CCSD
{
    internal class HuffmanCoder
    {
        private int[] _charFrequency = new int[256];
        private Dictionary<int, int> _charCode = new Dictionary<int, int>(),
            _codeLength = new Dictionary<int, int>();

        public HuffmanCoder()
        {
            for (int i = 0; i < 256; i++)
                _charFrequency[i] = decompressCharFrequency[i] = 0;
        }

        public void Compress(string inputFile, string outputFile)
        {
            CreateStatistics(inputFile);
            List<TreeNode<KeyValuePair<int, int>>> sortedCharsByFrequency = InitialSort(_charFrequency);
            TreeNode<KeyValuePair<int, int>> huffmanTree = BuildTree(sortedCharsByFrequency);
            InOrder(huffmanTree);

            Write(inputFile, outputFile);
        }

        private void Write(string inputFile, string outputFile)
        {
            using (BitWriter bitWriter = new BitWriter(outputFile))
            {
                //header
                WriteAlocationMap(bitWriter);
                WriteCharFrequencyOn4Bytes(bitWriter);

                FileInfo file = new FileInfo(inputFile);
                int numberOfBits = 8 * (int)file.Length;
                using (BitReader bitReader = new BitReader(inputFile))
                {
                    while (numberOfBits > 0)
                    {
                        int character = bitReader.readNBits(8);
                        bitWriter.WriteNBits(_charCode[character], _codeLength[character]);
                        numberOfBits -= 8;
                    }
                    bitWriter.WriteNBits(0, 7);
                }
            }
        }
        
        private void WriteCharFrequencyOn4Bytes(BitWriter bitWriter)
        {
            foreach (int cFrequency in _charFrequency)
                if (cFrequency != 0)
                    bitWriter.WriteNBits(cFrequency, 32);
        }

        private void WriteAlocationMap(BitWriter bitWriter)
        {
            foreach (int character in _charFrequency)
            {
                int bit = character == 0 ? 0 : 1;
                bitWriter.WriteBit(bit%2);
            }
        }

        public static byte ReverseByte(byte originalByte)
        {
            int result = 0;
            for (int i = 0; i < 8; i++)
            {
                result = result << 1;
                result += originalByte & 1;
                originalByte = (byte)(originalByte >> 1);
            }

            return (byte)result;
        }

        private void InOrder(TreeNode<KeyValuePair<int, int>> node)
        {
            if (node != null)
            {
                InOrder(node.leftChild);
                if (node.IsLeaf())
                {
                    string reverseCode = ComputeCode(node);
                    SaveCode(node.value.Key, reverseCode);
                }

                InOrder(node.rightChild);
            }
        }

        private string ComputeCode(TreeNode<KeyValuePair<int, int>> node)
        {
            string reverseCode = "";

            while (node.parent != null)
            {
                reverseCode += node.partialCode.ToString();
                node = node.parent;
            }

            if (node.isTheOnlyNode())
                reverseCode += node.partialCode.ToString();

            return reverseCode;
        }

        private void SaveCode(int key, string reverseCode)
        {
            _codeLength.Add(key, reverseCode.Length);
            _charCode.Add(key,Convert.ToInt32(reverseCode, 2));
        }

        private TreeNode<KeyValuePair<int, int>> BuildTree(List<TreeNode<KeyValuePair<int, int>>> sortedChars)
        {
            while (sortedChars.Count != 1)
            {
                KeyValuePair<int, int> keyValuePair =
                    new KeyValuePair<int, int>(sortedChars[0].value.Key + sortedChars[1].value.Key,
                        sortedChars[0].value.Value + sortedChars[1].value.Value);
                TreeNode<KeyValuePair<int, int>> tree = new TreeNode<KeyValuePair<int, int>>(keyValuePair)
                {
                    parent = null,
                    leftChild = sortedChars[0],
                    rightChild = sortedChars[1],
                };

                sortedChars[0].parent = sortedChars[1].parent = tree;
                sortedChars[0].partialCode = 0;
                sortedChars[1].partialCode = 1;
                sortedChars.RemoveRange(0, 2);
                sortedChars.Insert(0, tree);
                sortedChars.Sort(Comparison);
            }

            return sortedChars[0];
        }

        private List<TreeNode<KeyValuePair<int, int>>> InitialSort(int[] ints)
        {
            List<TreeNode<KeyValuePair<int, int>>> listOfChars = GetCharsThatAppear(_charFrequency);
            listOfChars.Sort(Comparison);

            return listOfChars;
        }

        private List<TreeNode<KeyValuePair<int, int>>> GetCharsThatAppear(int[] frequency)
        {
            List<TreeNode<KeyValuePair<int, int>>> listOfChars = new List<TreeNode<KeyValuePair<int, int>>>();

            for (int i = 0; i < frequency.Length; i++)
                if (frequency[i] != 0)
                {
                    KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(i, frequency[i]);
                    TreeNode<KeyValuePair<int, int>> treeNode = new TreeNode<KeyValuePair<int, int>>(keyValuePair);
                    listOfChars.Add(treeNode);
                }

            return listOfChars;
        }

        private int Comparison(TreeNode<KeyValuePair<int, int>> treeNode, TreeNode<KeyValuePair<int, int>> node)
        {
            return treeNode.value.Value.CompareTo(node.value.Value);
        }

        private void CreateStatistics(string inputFile)
        {
            FileInfo file = new FileInfo(inputFile);
            int numberOfBits = 8*(int) file.Length;

            using (BitReader bitReader = new BitReader(inputFile))
            {
                while (numberOfBits > 0)
                {
                    int character = bitReader.readNBits(8);
                    _charFrequency[character]++;
                    numberOfBits -= 8;
                }
            }
        }

        private int[] decompressCharFrequency = new int[256];

        public void Decompress(string inputFile, string outputFile)
        {
            using (BitReader bitReader = new BitReader(inputFile))
            {
                ReadAlocMap(bitReader);
                List<TreeNode<KeyValuePair<int, int>>> sortedCharsByFrequency = InitialSort(decompressCharFrequency);
                int fileLength = GetInitialFileSize(bitReader, sortedCharsByFrequency.Count);             
                TreeNode<KeyValuePair<int, int>> huffmanTree = BuildTree(sortedCharsByFrequency);

                using(BitWriter bitWriter = new BitWriter(outputFile))
                    DecodeAndWrite(bitReader, fileLength, huffmanTree, bitWriter);
            }
        }

        private void DecodeAndWrite(BitReader bitReader, int fileLength, TreeNode<KeyValuePair<int, int>> huffmanTree, BitWriter bitWriter)
        {
            TreeNode<KeyValuePair<int, int>> currentNode;
            
            for (int i = 0; i < fileLength; i++)
            {
                currentNode = huffmanTree;

                while (!currentNode.IsLeaf())
                {
                    int bit = bitReader.readBit();
                    currentNode = bit == 0 ? currentNode.leftChild : currentNode.rightChild;
                }

                //scrie caracterul
                int decodedChar = currentNode.value.Key;
                bitWriter.WriteNBits(decodedChar, 8);
            }
        }

        private int GetInitialFileSize(BitReader bitReader, int numberOfValues)
        {
            int sum = 0;
            string[] number = new string[4];

            for (int i = 0; i < numberOfValues; i++)
            {
                number[3] = Convert.ToString(bitReader.readNBits(8), 16);
                number[2] = Convert.ToString(bitReader.readNBits(8), 16);
                number[1] = Convert.ToString(bitReader.readNBits(8), 16);
                number[0] = Convert.ToString(bitReader.readNBits(8), 16);

                sum += Convert.ToInt32(number[0].PadLeft(2, '0') + number[1].PadLeft(2, '0') + number[2].PadLeft(2, '0') + number[3].PadLeft(2, '0'), 16);
            }

            return sum;
        }

        private void ReadAlocMap(BitReader bitReader)
        {
            for (int i = 0; i < 256; i++)
                decompressCharFrequency[i] = bitReader.readBit() & 1;
        }
    }
}
