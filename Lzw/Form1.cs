using System;
using System.Windows.Forms;
using CCSD;

namespace Lzw
{
    public partial class Form1 : Form
    {
        private LzwCoder lzwCoder;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxInputFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(numericUpDown1.Text);
            bool freeze = checkBoxFreeze.Checked;
            lzwCoder = new LzwCoder(freeze, index);
            string inputFile = textBoxInputFile.Text, 
                outputFile = string.Format("{0}.{1}L{2}.lzw",
                inputFile, freeze ? "F" : "E", index);

            lzwCoder.Compress(inputFile, outputFile);
        }

        private void buttonDecompress_Click(object sender, EventArgs e)
        {
            string inputFile = textBoxCompressFilePath.Text, outputFile, ext;
            int positionExtensionStart = inputFile.IndexOf(".");
            ext = inputFile.Substring(positionExtensionStart + 1, 3);

            outputFile = string.Format("{0}.{1}", inputFile, ext);

            lzwCoder.Decompress(inputFile, outputFile);
        }

        private void buttonLoadDecompressFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxCompressFilePath.Text = openFileDialog2.FileName;
            }
        }
    }
}
