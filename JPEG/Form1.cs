using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JPEG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int ELIMINARE_COEFICIENTI = 0;
        private const int MATRICE_SIMPLA_CALCULATA = 1;
        private const int FACTOR_DE_CALITATE_JPEG = 2;

        private int _metodaCuantizare = ELIMINARE_COEFICIENTI;

        String _originalFIlePath =
            "E:\\Visual studio\\Barglazan - Compresia, Criptarea si Securitatea Datelor\\CCSD\\JPEG\\Lenna256an.bmp";

        private void loadButton_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                _originalFIlePath = openFileDialog1.FileName;
                using (var fs = new FileStream(_originalFIlePath, FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    originalPictureBox.Image = (Bitmap)bmp.Clone();
                }
            }
            /*
            using (var fs = new FileStream(_originalFIlePath, FileMode.Open))
            {
                var bmp = new Bitmap(fs);
                originalPictureBox.Image = (Bitmap)bmp.Clone();
            }*/
        }

        int[,] dctY, YCuant;
        int[,] dctCb, dctCr, CbCuant, CrCuant;

        private void first3StepsButton_Click(object sender, EventArgs e)
        {
            //trans din RGB in YCbCr
            Bitmap originalBitmap = originalPictureBox.Image as Bitmap;
            var originalBitmapYCbCr = GetYCbCrBitmapFromRGB(originalBitmap);

            //subs
            byte[,] Y = new byte[256, 256];
            byte[,] Cb = new byte[128, 128];
            byte[,] Cr = new byte[128, 128];

            for (int y = 0; y < originalBitmapYCbCr.Height; y++)
            {
                for (int x = 0; x < originalBitmapYCbCr.Width; x++)
                {
                    Y[y, x] = originalBitmapYCbCr.GetPixel(x, y).R;

                    if (x % 2 == 0 && y % 2 == 0)
                    {

                        Cb[y / 2, x / 2] = originalBitmapYCbCr.GetPixel(x, y).B;
                        Cr[y / 2, x / 2] = originalBitmapYCbCr.GetPixel(x, y).G;

                    }
                }
            }

            //DCT
            dctY = CalculateDctFor(Y);
            dctCb = CalculateDctFor(Cb);
            dctCr = CalculateDctFor(Cr);

            lastStepsButton.Enabled = true;
        }

        private int[,] CalculateDctFor(byte[,] matrix)
        {
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1);
            int[,] dct = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    dct[i, j] = (int)(ApplyDCTFromula(i, j, matrix));

            return dct;
        }

        private double ApplyDCTFromula(int i, int j, byte[,] matrix)
        {
            double temp = 0.0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int pixel = matrix[y + i / 8 * 8, x + j / 8 * 8];
                    temp += Math.Cos(((2 * x + 1) * (i % 8) * Math.PI) / 16) * Math.Cos(((2 * y + 1) * (j % 8) * Math.PI) / 16) * pixel;
                }
            }

            double ci = (i % 8 == 0) ? 1 / Math.Sqrt(2) : 1;
            double cj = (j % 8 == 0) ? 1 / Math.Sqrt(2) : 1;
            temp = temp * 0.25 * ci * cj;

            return temp;
        }

        private Bitmap GetYCbCrBitmapFromRGB(Bitmap originalBitmap)
        {
            Bitmap bitmap = new Bitmap(256, 256);

            for (int y = 0; y < originalBitmap.Height; y++)
            {
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    Color currentPixel = originalBitmap.GetPixel(x, y);
                    currentPixel = TransformInYCbCr(currentPixel);
                    bitmap.SetPixel(x, y, currentPixel);
                }
            }

            return bitmap;
        }

        private Color TransformInYCbCr(Color currentPixel)
        {
            byte y = (byte)(0.299 * currentPixel.R + 0.587 * currentPixel.G + 0.114 * currentPixel.B);
            byte cr = (byte)(-0.172 * currentPixel.R - 0.339 * currentPixel.G + 0.511 * currentPixel.B + 128);
            byte cb = (byte)(0.511 * currentPixel.R - 0.428 * currentPixel.G - 0.083 * currentPixel.B + 128);

            return Color.FromArgb(y, cr, cb);
        }

        private void eliminareCoeficientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _metodaCuantizare = ELIMINARE_COEFICIENTI;
        }

        private void matriceSimplaCalculataRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _metodaCuantizare = MATRICE_SIMPLA_CALCULATA;
        }

        private void factorCalitateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _metodaCuantizare = FACTOR_DE_CALITATE_JPEG;
        }

        private void lastStepsButton_Click(object sender, EventArgs e)
        {
            Cuant();
            ICuant();

            //idct
            int[,] iDctY = CalculateIDctFor(iYCuant);
            int[,] iDctCb = CalculateIDctFor(iCbCuant);
            int[,] iDctCr = CalculateIDctFor(iCrCuant);

            //isub
            byte[,] Y = new byte[256, 256];
            byte[,] Cb = new byte[256, 256];
            byte[,] Cr = new byte[256, 256];

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    Y[y, x] = (byte)iDctY[y, x];

                    if (x < 128 && y < 128)
                    {
                        Cb[y * 2, x * 2] = Cb[y * 2, 2 * x + 1] = Cb[2 * y + 1, 2 * x] = Cb[2 * y + 1, 2 * x + 1] = (byte)iDctCb[y, x];
                        Cr[y * 2, x * 2] = Cr[y * 2, 2 * x + 1] = Cr[2 * y + 1, 2 * x] = Cr[2 * y + 1, 2 * x + 1] = (byte)iDctCr[y, x];
                    }
                }
            }

            //itrans

            Bitmap bmpReconstructed = GetRGBBitmapFromYCbCr(Y, Cb, Cr);

            redonePictureBoxP.Image = bmpReconstructed;

        }

        private Bitmap GetRGBBitmapFromYCbCr(byte[,] Y, byte[,] Cb, byte[,] Cr)
        {
            Bitmap bmp = new Bitmap(256, 256);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    Color pixelColor = TransformInRGB(Y[i, j], Cb[i, j], Cr[i, j]);
                    bmp.SetPixel(j, i, pixelColor);
                }
            }

            return bmp;
        }

        private Color TransformInRGB(byte Y, byte Cb, byte Cr)
        {
            byte R = (byte)(Y + 0.000 * (Cb - 128) + 1.371 * (Cr - 128));
            byte G = (byte)(Y - 0.336 * (Cb - 128) - 0.698 * (Cr - 128));
            byte B = (byte)(Y + 1.732 * (Cb - 128) + 0.000 * (Cr - 128));

            return Color.FromArgb(R, G, B);
        }

        private int[,] CalculateIDctFor(int[,] matrix)
        {
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1);

            int[,] iDct = new int[n, m];

            for (int y = 0; y < n; y++)
                for (int x = 0; x < m; x++)
                    iDct[y, x] = (int)ApplyIDctFromula(y, x, matrix);

            return iDct;
        }

        private int ApplyIDctFromula(int y, int x, int[,] matrix)
        {
            double temp = 0.0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    double ci = (i == 0) ? 1 / Math.Sqrt(2) : 1;
                    double cj = (j == 0) ? 1 / Math.Sqrt(2) : 1;

                    double t = ci * cj * matrix[i + y / 8 * 8, j + x / 8 * 8];
                    temp += t * Math.Cos(((2 * (x % 8) + 1) * i * Math.PI) / 16) * Math.Cos(((2 * (y % 8) + 1) * j * Math.PI) / 16);
                }
            }

            return (int)(0.25 * temp);
        }

        int[,] iYCuant, iCbCuant, iCrCuant;
        private void ICuant()
        {
            iYCuant = new int[256, 256];
            iCbCuant = iCrCuant = new int[128, 128];

            int[,] Qxy = GetQxy();

            if (_metodaCuantizare == MATRICE_SIMPLA_CALCULATA)
            {
                ApplyIQuantizationMatrixToYMatrix(Qxy);
                ApplyIQuantizationMatrixToCbCrMatrix(Qxy);
            }
            else
            {
                int[,] cbQxy = GetCbCrQxy();

                if (_metodaCuantizare == FACTOR_DE_CALITATE_JPEG)
                {
                    ApplyIQuantizationMatrixToYMatrix(Qxy);
                    ApplyIQuantizationMatrixToCbCrMatrix(cbQxy);
                }

                if (_metodaCuantizare == ELIMINARE_COEFICIENTI)
                {
                    iYCuant = YCuant;
                    iCbCuant = CbCuant;
                    iCrCuant = CrCuant;
                }

            }
        }

        private void ApplyIQuantizationMatrixToCbCrMatrix(int[,] Qxy)
        {
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    iCbCuant[y, x] = CbCuant[y, x] * Qxy[y % 8, x % 8];
                    iCrCuant[y, x] = CrCuant[y, x] * Qxy[y % 8, x % 8];
                }
            }
        }

        private void ApplyIQuantizationMatrixToYMatrix(int[,] Qxy)
        {
            for (int y = 0; y < 256; y++)
                for (int x = 0; x < 256; x++)
                    iYCuant[y, x] = YCuant[y, x] * Qxy[y % 8, x % 8];
        }

        private void Cuant()
        {
            YCuant = new int[256, 256];
            CbCuant = CrCuant = new int[128, 128];

            int[,] Qxy = GetQxy();

            if (_metodaCuantizare == MATRICE_SIMPLA_CALCULATA)
            {
                ApplyQuantizationMatrixToYMatrix(Qxy);
                ApplyQUantizationMatrixToCbCr(Qxy);

            }
            else
            {
                int[,] cbQxy = GetCbCrQxy();

                if (_metodaCuantizare == FACTOR_DE_CALITATE_JPEG)
                {
                    ApplyQuantizationMatrixToYMatrix(Qxy);
                    ApplyQUantizationMatrixToCbCr(cbQxy);
                }

                if (_metodaCuantizare == ELIMINARE_COEFICIENTI)
                {
                    ApplyZigZagPatternToYMatrix();
                    ApplyZigZagPatternToCbCrMatrix();
                }
            }
        }

        private void ApplyZigZagPatternToCbCrMatrix()
        {
            int n = (int)coeficientNumericUpDown.Value;
            int[,] cuantDct = ZigZagMatrix(n);

            for (int y = 0; y < 128; y++)
                for (int x = 0; x < 128; x++)
                    if (cuantDct[y % 8, x % 8] == 0)
                        CrCuant[y, x] = CbCuant[y, x] = 0;
                    else
                    {
                        CrCuant[y, x] = dctCr[y, x];
                        CbCuant[y, x] = dctCb[y, x];
                    }
        }

        private void ApplyZigZagPatternToYMatrix()
        {
            int n = (int)coeficientNumericUpDown.Value;
            int[,] cuantDct = ZigZagMatrix(n);

            for (int y = 0; y < 256; y++)
                for (int x = 0; x < 256; x++)
                    if (cuantDct[y % 8, x % 8] == 0)
                        YCuant[y, x] = 0;
                    else
                        YCuant[y, x] = dctY[y, x];
        }

        private int[,] GetCbCrQxy()
        {
            int[,] CbCrQxy = new int[,]
                {
                    {17, 18, 24, 47, 99, 99, 99, 99},
                    {18, 21, 26, 66, 99, 99, 99, 99},
                    {24, 26, 56, 99, 99, 99, 99, 99},
                    {47, 66, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99}
                };

            if (_metodaCuantizare == FACTOR_DE_CALITATE_JPEG)
            {
                int qJpeg = (int)factorCalitateNumericUpDown.Value;
                double value = 1;

                if (qJpeg <= 50)
                    value = 50.0 / qJpeg;
                if (qJpeg > 50 && qJpeg <= 99)
                    value = (2 - qJpeg) / 50.0;

                if (qJpeg != 100)
                {
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            CbCrQxy[i, j] = (int)(value * CbCrQxy[i, j]);
                }
            }

            return CbCrQxy;
        }

        private void ApplyQUantizationMatrixToCbCr(int[,] Qxy)
        {
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    CbCuant[y, x] = dctCb[y, x] / Qxy[y % 8, x % 8];
                    CrCuant[y, x] = dctCr[y, x] / Qxy[y % 8, x % 8];
                }
            }
        }

        private void ApplyQuantizationMatrixToYMatrix(int[,] Qxy)
        {
            for (int y = 0; y < 256; y++)
                for (int x = 0; x < 256; x++)
                    YCuant[y, x] = dctY[y, x] / Qxy[y % 8, x % 8];
        }

        private int[,] ZigZagMatrix(int n)
        {
            int[,] dct = new int[8, 8];
            int y = 1, x = 1;

            for (int i = 0; i < 64; i++)
            {
                if (i >= n)
                    dct[y - 1, x - 1] = 0;
                else
                    dct[y - 1, x - 1] = -1;

                if ((y + x) % 2 == 0)
                {
                    if (x < 8)
                        x++;
                    else
                        y += 2;

                    if (y > 1)
                        y--;
                }
                else
                {
                    if (y < 8)
                        y++;
                    else
                        x += 2;

                    if (x > 1)
                        x--;
                }
            }

            return dct;
        }

        private int[,] GetQxy()
        {
            int[,] Qxy = new int[8, 8];

            if (_metodaCuantizare == MATRICE_SIMPLA_CALCULATA)
            {
                int r = (int)matriceSimplaCalculataNumericUpDown.Value;

                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        Qxy[i, j] = 1 + (i + j) * r;
            }
            else
            {
                Qxy = new int[,]
                {
                    {16, 11, 10, 16, 24, 40, 51, 61},
                    {12, 12, 14, 19, 26, 58, 60, 55},
                    {14, 13, 16, 24, 40, 57, 69, 56},
                    {14, 17, 22, 29, 51, 87, 80, 62},
                    {18, 22, 37, 56, 68, 109, 103, 77},
                    {24, 35, 55, 64, 81, 104, 113, 92},
                    {49, 64, 78, 87, 103, 121, 120, 101},
                    {72, 92, 95, 98, 112, 100, 103, 99}
                };

                if (_metodaCuantizare == FACTOR_DE_CALITATE_JPEG)
                {
                    int qJpeg = (int)factorCalitateNumericUpDown.Value;
                    double value = 1;

                    if (qJpeg <= 50)
                        value = 50.0 / qJpeg;
                    if (qJpeg > 50 && qJpeg <= 99)
                        value = (2 - qJpeg) / 50.0;

                    if (qJpeg != 100)
                    {
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                Qxy[i, j] = (int)(value * Qxy[i, j]);
                    }
                }
            }

            return Qxy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double errorR = 0;
            double errorG = 0;
            double errorB = 0;
            ErrorR(ref errorR, ref errorG, ref errorB);

            eroarePatraticaTextBox.Text = string.Format("R: {0}, G: {1}, B: {2}", errorR, errorG, errorB);
        }

        private void ErrorR(ref double errorR, ref double errorG, ref double errorB)
        {
            Bitmap originalBitmap = originalPictureBox.Image as Bitmap;
            Bitmap reconstructedBitmap = redonePictureBoxP.Image as Bitmap;

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    errorR = Math.Pow(originalBitmap.GetPixel(x, y).R - reconstructedBitmap.GetPixel(x, y).R, 2);
                    errorG = Math.Pow(originalBitmap.GetPixel(x, y).G - reconstructedBitmap.GetPixel(x, y).G, 2);
                    errorB = Math.Pow(originalBitmap.GetPixel(x, y).B - reconstructedBitmap.GetPixel(x, y).B, 2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double snrR = 0, snrG = 0, snrB = 0;

            double eroarePatraticaR = 0;
            double eroarePatraticaG = 0;
            double eroarePatraticaB = 0;
            ErrorR(ref eroarePatraticaR, ref eroarePatraticaG, ref eroarePatraticaB);

            double sumR = 0;
            double sumG = 0;
            double sumB = 0;
            Bitmap originalBitmap = originalPictureBox.Image as Bitmap;

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    sumR = Math.Pow(originalBitmap.GetPixel(x, y).R, 2);
                    sumG = Math.Pow(originalBitmap.GetPixel(x, y).G, 2);
                    sumB = Math.Pow(originalBitmap.GetPixel(x, y).B, 2);
                }
            }

            snrR = 10 * Math.Log(sumR / eroarePatraticaR);
            snrG = 10 * Math.Log(sumG / eroarePatraticaG);
            snrB = 10 * Math.Log(sumB / eroarePatraticaB);

            SNRTextBox.Text = string.Format("R: {0}, G: {1}, B: {2}", snrR, snrG, snrB);

        }
    }
}
