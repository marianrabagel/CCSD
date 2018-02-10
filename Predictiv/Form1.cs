using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CCSD;

namespace Predictiv
{
    public partial class Form1 : Form
    {
        private const int _128 = 0;
        private const int A = 1;
        private const int B = 2;
        private const int C = 3;
        private const int ABC = 4;
        private const int ABC2 = 5;
        private const int BAC2 = 6;
        private const int AB2 = 7;
        private const int JPEGLS = 8;

        public Form1()
        {
            InitializeComponent();
        }

        String _originalFIlePath =
            "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\Predictiv\\Lenna256an.bmp";
            
        int _predictor = A;
        double _scale = 1;
        string _histogram = "O";

        int[,] _errorMatrix = new int[256, 256];
        Bitmap _originalBitmap;

        private void loadOriginalButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                _originalFIlePath = openFileDialog1.FileName;
                
                using (var fs = new FileStream(_originalFIlePath, FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    originalPictureBox.Image = (Bitmap) bmp.Clone();
                }

                predictButton.Enabled = true;
                saveButton.Enabled = true;
                drawHistogrambutton.Enabled = true;
            }
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            _originalBitmap = originalPictureBox.Image as Bitmap;
            Bitmap predictedBitmap = new Bitmap(256, 256);

            for (int rows = 0; rows < _originalBitmap.Height; rows++)
            {
                for (int cols = 0; cols < _originalBitmap.Width; cols++)
                {
                    var originalPixel = _originalBitmap.GetPixel(cols, rows);
                    var predictedPixel = PredictPixel(cols, rows, _originalBitmap);
                    predictedBitmap.SetPixel(cols, rows, predictedPixel);
                    _errorMatrix[rows, cols] = CalculateError(originalPixel, predictedPixel);
                }
            }
        }

        private int CalculateError(Color originalPixel, Color predictedPixel)
        {
            return originalPixel.R - predictedPixel.R;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            Bitmap errorBitmap = new Bitmap(256, 256);

            for (int rows = 0; rows < _errorMatrix.GetLength(0); rows++)
                for (int cols = 0; cols < _errorMatrix.GetLength(1); cols++)
                {
                    var errorPixel = CalculateErrorForDisplay(_errorMatrix[rows, cols]);
                    errorBitmap.SetPixel(cols, rows, errorPixel);
                }

            errorPictureBox.Image = errorBitmap;
        }

        private Color PredictPixel(int x, int y, Bitmap originalBitmap)
        {
            if (x == 0 && y == 0)
            {
                return Color.FromArgb(128, 128, 128);
            }

            Color predictedPixel = Color.FromArgb(128, 128, 128);
            Color pixelA = new Color(), pixelB = new Color(), pixelC = new Color();
            int r, g, b;

            switch (_predictor)
            {
                case _128:
                    predictedPixel = Color.FromArgb(128, 128, 128);
                    break;
                case A:
                    predictedPixel = x == 0 ? Color.FromArgb(128, 128, 128) : originalBitmap.GetPixel(x - 1, y);
                    break;
                case B:
                    predictedPixel = y == 0 ? Color.FromArgb(128, 128, 128) : originalBitmap.GetPixel(x, y - 1);
                    break;
                case C:
                    if (y == 0 || x == 0)
                        predictedPixel = Color.FromArgb(128, 128, 128);
                    else
                        predictedPixel = originalBitmap.GetPixel(x - 1, y - 1);
                    break;
                case ABC:
                    GetPixelABC(ref pixelA, ref pixelB, ref pixelC, originalBitmap, x, y);
                    
                    r = GreaterThen0LesserThan255(pixelA.R + pixelB.R - pixelC.R);
                    g = GreaterThen0LesserThan255(pixelA.G + pixelB.G - pixelC.G);
                    b = GreaterThen0LesserThan255(pixelA.B + pixelB.B - pixelC.B);

                    predictedPixel = Color.FromArgb(r, g, b);
                    break;
                case ABC2:
                    GetPixelABC(ref pixelA, ref pixelB, ref pixelC, originalBitmap, x, y);
                    
                    r = GreaterThen0LesserThan255(pixelA.R + (pixelB.R - pixelC.R)/2);
                    g = GreaterThen0LesserThan255(pixelA.G + (pixelB.G - pixelC.G)/2);
                    b = GreaterThen0LesserThan255(pixelA.B + (pixelB.B - pixelC.B)/2);

                    predictedPixel = Color.FromArgb(r, g, b);
                    break;
                case BAC2:
                    GetPixelABC(ref pixelA, ref pixelB, ref pixelC, originalBitmap, x, y);
                    
                    r = GreaterThen0LesserThan255(pixelB.R + (pixelA.R - pixelC.R)/2);
                    g = GreaterThen0LesserThan255(pixelB.G + (pixelA.G - pixelC.G)/2);
                    b = GreaterThen0LesserThan255(pixelB.B + (pixelA.B - pixelC.B)/2);

                    predictedPixel = Color.FromArgb(r, g, b);
                    break;
                case AB2:
                    GetPixelABC(ref pixelA, ref pixelB, ref pixelC, originalBitmap, x, y);
                    
                    r = GreaterThen0LesserThan255((pixelA.R + pixelB.R)/2);
                    g = GreaterThen0LesserThan255((pixelA.G + pixelB.G)/2);
                    b = GreaterThen0LesserThan255((pixelA.B + pixelB.B)/2);

                    predictedPixel = Color.FromArgb(r, g, b);
                    break;
                case JPEGLS:
                    GetPixelABC(ref pixelA, ref pixelB, ref pixelC, originalBitmap, x, y);

                    r = GreaterThen0LesserThan255(Jpegls(pixelA.R, pixelB.R, pixelC.R));
                    g = GreaterThen0LesserThan255(Jpegls(pixelA.G, pixelB.G, pixelC.G));
                    b = GreaterThen0LesserThan255(Jpegls(pixelA.B, pixelB.B, pixelC.B));

                    predictedPixel = Color.FromArgb(r, g, b);
                    break;
            }

            return predictedPixel;
        }

        private int Jpegls(int a, int b, int c)
        {
            int value = a + b - c;

            if (c >= Math.Max(a, b))
                value = Math.Min(a, b);
            if (c <= Math.Min(a, b))
                value = Math.Max(a, b);

            return value;
        }

        private int GreaterThen0LesserThan255(int value)
        {
            if (value < 0)
                value = 0;
            if (value > 255)
                value = 255;

            return value;
        }

        private void GetPixelABC(ref Color pixelA, ref Color pixelB, ref Color pixelC, Bitmap originalBitmap, int x, int y)
        {
            if (y == 0)
            {
                pixelB = pixelC = Color.FromArgb(128, 128, 128);
                pixelA = originalBitmap.GetPixel(x - 1, y);
            }
            else if (x == 0)
            {
                pixelA = pixelC = Color.FromArgb(128, 128, 128);
                pixelB = originalBitmap.GetPixel(x, y - 1);
            }
            else
            {
                pixelA = originalBitmap.GetPixel(x - 1, y);
                pixelB = originalBitmap.GetPixel(x, y - 1);
                pixelC = originalBitmap.GetPixel(x - 1, y - 1);
            }
        }

        private Color CalculateErrorForDisplay(int error)
        {
            _scale = (double) scaleNumericUpDown.Value;
            int errorR = GreaterThen0LesserThan255((int) (128+error*_scale));
            int errorG = GreaterThen0LesserThan255((int) (128+error*_scale));
            int errorB = GreaterThen0LesserThan255((int) (128+error*_scale));
            
            return Color.FromArgb(errorR, errorG, errorB);
        }


        private void buttonDrawHistogram_Click(object sender, EventArgs e)
        {
            //folosti un panel
            //se desenezi pe rand
            //max range pe y -> 300
            //originalul va fi doar in intervalul[0-255]
            //eroarea va fi in intervalul [-255,255]

            Dictionary<int, int> pixelFrequency = GetPixelFrequency();
            double scale = (double) scaleHistogramNumericUpDown.Value;

            DrawGraphicsOn(histogramPanel, pixelFrequency, scale);
        }

        private void DrawGraphicsOn(Panel panel, Dictionary<int, int> pixelFrequency, double scale)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                g.Clear(Color.White);
                g.ScaleTransform(1.0F, -1.0f);
                g.TranslateTransform(0.0F, -(float) panel.Height);

                foreach (KeyValuePair<int, int> keyValuePair in pixelFrequency)
                {
                    var y = keyValuePair.Value*scale;
                    var x = keyValuePair.Key + panel.Width/2;

                    g.DrawLine(Pens.Black,
                        new Point(x, 0),
                        new Point(x, (int) y));
                }
            }
        }

        private Dictionary<int, int> GetPixelFrequency()
        {
            int size = GetValueRange();
            Dictionary<int, int> pixelFrequency = new Dictionary<int, int>(size);

            for (int i = 0; i < size; i++)
                pixelFrequency.Add(255 - i, 0);

            int width = GetWidth();
            int height = GetHeight();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixelValue = GetPixelValue(x, y);
                    pixelFrequency[pixelValue]++;
                }
            }

            return pixelFrequency;
        }

        private int GetValueRange()
        {
            return radioButtonEroare.Checked ? 512 : 256;
        }

        private int GetHeight()
        {
            int height = _originalBitmap.Height;

            if (radioButtonEroare.Checked)
                height = _errorMatrix.GetLength(0);
            if (radioButtonDecoded.Checked)
                height = _reconstructedBitmap.Height;

            return height;
        }

        private int GetWidth()
        {
            int width = _originalBitmap.Width;

            if (radioButtonEroare.Checked)
                width = _errorMatrix.GetLength(1);
            if (radioButtonDecoded.Checked)
                width = _reconstructedBitmap.Width;

            return width;
        }

        private int GetPixelValue(int x, int y)
        {
            int value = _originalBitmap.GetPixel(x, y).R;
            
            if (radioButtonEroare.Checked)
                value = _errorMatrix[y, x];
            if (radioButtonDecoded.Checked)
                value = _reconstructedBitmap.GetPixel(x, y).R;

            return value;

        }


        private void radioButton128_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton128.Checked)
                _predictor = _128;
        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonA.Checked)
                _predictor = A;
        }

        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonB.Checked)
                _predictor = B;
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonC.Checked)
                _predictor = C;
        }

        private void radioButtonABC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonABC.Checked)
                _predictor = ABC;
        }

        private void radioButtonABC2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonABC2.Checked)
                _predictor = ABC2;
        }

        private void radioButtonBAC2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBAC2.Checked)
                _predictor = BAC2;
        }

        private void radioButtonAB2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAB2.Checked)
                _predictor = AB2;
        }

        private void radioButtonJpegLS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonJpegLS.Checked)
                _predictor = JPEGLS;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            string ext = "pre";
            string outputfileName = string.Format("{0}.[{1}].{2}", _originalFIlePath, _predictor, ext);
            
            int count = 1078;
            byte[] buffer = new byte[count];

            GetFirstBytes(count, buffer, _originalFIlePath);

            using (BitWriter bitWriter = new BitWriter(outputfileName))
            {
                foreach (byte b in buffer)
                    bitWriter.Write(b, 8);
                
                bitWriter.Write((uint) _predictor, 4);
                //send
                WriteToFile(bitWriter, _errorMatrix);
                bitWriter.Write(0, 7);
            }
        }

        private void GetFirstBytes(int count, byte[] buffer, string filePath)
        {
            int offset = 0;

            using (Stream stream = new FileStream(filePath, FileMode.Open))
            {
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count);

                    if (read == 0)
                        throw new EndOfStreamException();

                    offset += read;
                }
            }
        }

        private void WriteToFile(BitWriter bitWriter, int[,] errorMatrix)
        {
            for (int row = 0; row < errorMatrix.GetLength(0); row++)
            {
                for (int cols = 0; cols < errorMatrix.GetLength(1); cols++)
                {
                    bitWriter.Write((uint) errorMatrix[row, cols], 9);
                }
            }
        }

        int[,] _errorMatrixFromFile = new int[256, 256];
        string _encodedFilePath;
        
        private void loadPredictedImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                _encodedFilePath = openFileDialog2.FileName;
                FileInfo file = new FileInfo(_encodedFilePath);
                int numberOfBits = 8 * (int)file.Length;
                
                using (BitReader bitReader = new BitReader(_encodedFilePath))
                {
                    bitReader.ReadNBit(1078*8);
                    numberOfBits -= 1078*8;
                    _predictor = (int)bitReader.ReadNBit(4);
                    numberOfBits -= 4;
                    int i = 0;
                    
                    while (numberOfBits > 9)
                    {
                        Int16 value = (short) bitReader.ReadNBit(9);
                        
                        if ((value & 0x0100) != 0)
                            value = (short) (value | 0xFF00);
                        
                        numberOfBits -= 9;
                        _errorMatrixFromFile[i/256, i%256] = value;
                        i++;
                    }
                }
            }
        }
        
        Bitmap _reconstructedBitmap;

        private void decodeButton_Click(object sender, EventArgs e)
        {
            _reconstructedBitmap = new Bitmap(256, 256);
            Bitmap predictedBitmap = new Bitmap(256, 256);

            for (int rows = 0; rows < _reconstructedBitmap.Width; rows++)
            {
                for (int cols = 0; cols < _reconstructedBitmap.Width; cols++)
                {
                    var predictedPixel = PredictPixel(cols, rows, _reconstructedBitmap);
                    predictedBitmap.SetPixel(cols, rows, predictedPixel);

                    Color pixel = CalculatePixelForReconstructedBitmap(_errorMatrixFromFile[rows, cols], predictedPixel);
                    _reconstructedBitmap.SetPixel(cols, rows, pixel);
                }
            }

            predictedPictureBox.Image = predictedBitmap;
        }

        private Color CalculatePixelForReconstructedBitmap(int color, Color predictedPixel)
        {
            return Color.FromArgb(predictedPixel.R + color, predictedPixel.R + color, predictedPixel.R + color);
        }

        private void savePredictedButton_Click(object sender, EventArgs e)
        {
            string ext = "decoded";
            string outputfileName = string.Format("{0}.{1}", _encodedFilePath, ext);
            
            int count = 1078;
            byte[] buffer = new byte[count];

            GetFirstBytes(count, buffer, _encodedFilePath);
            
            using (BitWriter bitWriter = new BitWriter(outputfileName))
            {
                foreach (byte b in buffer)
                    bitWriter.Write(b, 8);

                WriteToFile(bitWriter, predictedPictureBox.Image as Bitmap);
                //WriteToFile(bitWriter, _reconstructedBitmap);
                bitWriter.Write(0, 7);
            }
        }

        private void WriteToFile(BitWriter bitWriter, Bitmap reconstructedBitmap)
        {
            for (int rows = 0; rows < reconstructedBitmap.Width; rows++)
                for (int cols = 0; cols < reconstructedBitmap.Width; cols++)               
                    bitWriter.Write(reconstructedBitmap.GetPixel(cols, rows).R, 8);
        }
    }
}
