using System;
using System.Windows.Forms;
using CCSD;

namespace Lz77
{
    
    public partial class Form1 : Form
    {
        private Lz77Coder lz77Coder;
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
                int a;
            }
        }

        private void BtnEncode_Click(object sender, EventArgs e)
        {
            int searchBufferLength = Convert.ToInt32(numericUpDownOffset.Text);
            int lookAheadBufferLength = Convert.ToInt32(numericUpDownLength.Text);
            lz77Coder = new Lz77Coder(searchBufferLength,lookAheadBufferLength);

            string inputFile = textBoxInputFile.Text,
                outputFile = string.Format("{0}.O{1}L{2}.lz77", 
                inputFile, searchBufferLength, lookAheadBufferLength);
            
            lz77Coder.Compress(inputFile,outputFile);
        }

        private void BtnLoadCompressed_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogCompressedFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxCompressedInputFIle.Text = openFileDialogCompressedFile.FileName;
            }
        }

        private void BtnDecode_Click(object sender, EventArgs e)
        {
            string inputFile = textBoxCompressedInputFIle.Text, outputFile, ext;
            int positionExtensionStart = inputFile.IndexOf(".");
            ext = inputFile.Substring(positionExtensionStart + 1, 3);

            outputFile = string.Format("{0}.{1}", inputFile, ext);

            lz77Coder.Decompress(inputFile, outputFile);
        }
    }
}
