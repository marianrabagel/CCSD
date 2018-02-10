namespace Predictiv
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.errorPictureBox = new System.Windows.Forms.PictureBox();
            this.predictedPictureBox = new System.Windows.Forms.PictureBox();
            this.loadOriginalButton = new System.Windows.Forms.Button();
            this.predictButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.savePredictedButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.loadPredictedImageButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.radioButton128 = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonAB2 = new System.Windows.Forms.RadioButton();
            this.radioButtonBAC2 = new System.Windows.Forms.RadioButton();
            this.radioButtonABC2 = new System.Windows.Forms.RadioButton();
            this.radioButtonABC = new System.Windows.Forms.RadioButton();
            this.radioButtonJpegLS = new System.Windows.Forms.RadioButton();
            this.radioButtonOriginal = new System.Windows.Forms.RadioButton();
            this.radioButtonEroare = new System.Windows.Forms.RadioButton();
            this.radioButtonDecoded = new System.Windows.Forms.RadioButton();
            this.drawHistogrambutton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleHistogramNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.histogramPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predictedPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHistogramNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Location = new System.Drawing.Point(12, 5);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(256, 256);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(326, 5);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(256, 256);
            this.errorPictureBox.TabIndex = 1;
            this.errorPictureBox.TabStop = false;
            // 
            // predictedPictureBox
            // 
            this.predictedPictureBox.Location = new System.Drawing.Point(623, 5);
            this.predictedPictureBox.Name = "predictedPictureBox";
            this.predictedPictureBox.Size = new System.Drawing.Size(256, 256);
            this.predictedPictureBox.TabIndex = 2;
            this.predictedPictureBox.TabStop = false;
            // 
            // loadOriginalButton
            // 
            this.loadOriginalButton.Location = new System.Drawing.Point(12, 267);
            this.loadOriginalButton.Name = "loadOriginalButton";
            this.loadOriginalButton.Size = new System.Drawing.Size(69, 23);
            this.loadOriginalButton.TabIndex = 3;
            this.loadOriginalButton.Text = "Load";
            this.loadOriginalButton.UseVisualStyleBackColor = true;
            this.loadOriginalButton.Click += new System.EventHandler(this.loadOriginalButton_Click);
            // 
            // predictButton
            // 
            this.predictButton.Enabled = false;
            this.predictButton.Location = new System.Drawing.Point(96, 267);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(75, 23);
            this.predictButton.TabIndex = 4;
            this.predictButton.Text = "Predict";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(193, 267);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // savePredictedButton
            // 
            this.savePredictedButton.Location = new System.Drawing.Point(804, 267);
            this.savePredictedButton.Name = "savePredictedButton";
            this.savePredictedButton.Size = new System.Drawing.Size(75, 23);
            this.savePredictedButton.TabIndex = 9;
            this.savePredictedButton.Text = "Save";
            this.savePredictedButton.UseVisualStyleBackColor = true;
            this.savePredictedButton.Click += new System.EventHandler(this.savePredictedButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(707, 267);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(75, 23);
            this.decodeButton.TabIndex = 8;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // loadPredictedImageButton
            // 
            this.loadPredictedImageButton.Location = new System.Drawing.Point(623, 267);
            this.loadPredictedImageButton.Name = "loadPredictedImageButton";
            this.loadPredictedImageButton.Size = new System.Drawing.Size(69, 23);
            this.loadPredictedImageButton.TabIndex = 7;
            this.loadPredictedImageButton.Text = "Load";
            this.loadPredictedImageButton.UseVisualStyleBackColor = true;
            this.loadPredictedImageButton.Click += new System.EventHandler(this.loadPredictedImageButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(501, 267);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 10;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // radioButton128
            // 
            this.radioButton128.AutoSize = true;
            this.radioButton128.Location = new System.Drawing.Point(6, 19);
            this.radioButton128.Name = "radioButton128";
            this.radioButton128.Size = new System.Drawing.Size(43, 17);
            this.radioButton128.TabIndex = 12;
            this.radioButton128.Text = "128";
            this.radioButton128.UseVisualStyleBackColor = true;
            this.radioButton128.CheckedChanged += new System.EventHandler(this.radioButton128_CheckedChanged);
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Checked = true;
            this.radioButtonA.Location = new System.Drawing.Point(6, 42);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(32, 17);
            this.radioButtonA.TabIndex = 13;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.Text = "A";
            this.radioButtonA.UseVisualStyleBackColor = true;
            this.radioButtonA.CheckedChanged += new System.EventHandler(this.radioButtonA_CheckedChanged);
            // 
            // radioButtonC
            // 
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Location = new System.Drawing.Point(6, 88);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(32, 17);
            this.radioButtonC.TabIndex = 15;
            this.radioButtonC.Text = "C";
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.CheckedChanged += new System.EventHandler(this.radioButtonC_CheckedChanged);
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(6, 65);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(32, 17);
            this.radioButtonB.TabIndex = 14;
            this.radioButtonB.Text = "B";
            this.radioButtonB.UseVisualStyleBackColor = true;
            this.radioButtonB.CheckedChanged += new System.EventHandler(this.radioButtonB_CheckedChanged);
            // 
            // radioButtonAB2
            // 
            this.radioButtonAB2.AutoSize = true;
            this.radioButtonAB2.Location = new System.Drawing.Point(6, 180);
            this.radioButtonAB2.Name = "radioButtonAB2";
            this.radioButtonAB2.Size = new System.Drawing.Size(74, 17);
            this.radioButtonAB2.TabIndex = 19;
            this.radioButtonAB2.Text = "(A + B) / 2";
            this.radioButtonAB2.UseVisualStyleBackColor = true;
            this.radioButtonAB2.CheckedChanged += new System.EventHandler(this.radioButtonAB2_CheckedChanged);
            // 
            // radioButtonBAC2
            // 
            this.radioButtonBAC2.AutoSize = true;
            this.radioButtonBAC2.Location = new System.Drawing.Point(6, 157);
            this.radioButtonBAC2.Name = "radioButtonBAC2";
            this.radioButtonBAC2.Size = new System.Drawing.Size(90, 17);
            this.radioButtonBAC2.TabIndex = 18;
            this.radioButtonBAC2.Text = "B + (A - C) / 2";
            this.radioButtonBAC2.UseVisualStyleBackColor = true;
            this.radioButtonBAC2.CheckedChanged += new System.EventHandler(this.radioButtonBAC2_CheckedChanged);
            // 
            // radioButtonABC2
            // 
            this.radioButtonABC2.AutoSize = true;
            this.radioButtonABC2.Location = new System.Drawing.Point(6, 134);
            this.radioButtonABC2.Name = "radioButtonABC2";
            this.radioButtonABC2.Size = new System.Drawing.Size(90, 17);
            this.radioButtonABC2.TabIndex = 17;
            this.radioButtonABC2.Text = "A + (B - C) / 2";
            this.radioButtonABC2.UseVisualStyleBackColor = true;
            this.radioButtonABC2.CheckedChanged += new System.EventHandler(this.radioButtonABC2_CheckedChanged);
            // 
            // radioButtonABC
            // 
            this.radioButtonABC.AutoSize = true;
            this.radioButtonABC.Location = new System.Drawing.Point(6, 111);
            this.radioButtonABC.Name = "radioButtonABC";
            this.radioButtonABC.Size = new System.Drawing.Size(67, 17);
            this.radioButtonABC.TabIndex = 16;
            this.radioButtonABC.Text = "A + B - C";
            this.radioButtonABC.UseVisualStyleBackColor = true;
            this.radioButtonABC.CheckedChanged += new System.EventHandler(this.radioButtonABC_CheckedChanged);
            // 
            // radioButtonJpegLS
            // 
            this.radioButtonJpegLS.AutoSize = true;
            this.radioButtonJpegLS.Location = new System.Drawing.Point(5, 203);
            this.radioButtonJpegLS.Name = "radioButtonJpegLS";
            this.radioButtonJpegLS.Size = new System.Drawing.Size(58, 17);
            this.radioButtonJpegLS.TabIndex = 20;
            this.radioButtonJpegLS.Text = "jpegLS";
            this.radioButtonJpegLS.UseVisualStyleBackColor = true;
            this.radioButtonJpegLS.CheckedChanged += new System.EventHandler(this.radioButtonJpegLS_CheckedChanged);
            // 
            // radioButtonOriginal
            // 
            this.radioButtonOriginal.AutoSize = true;
            this.radioButtonOriginal.Checked = true;
            this.radioButtonOriginal.Location = new System.Drawing.Point(16, 23);
            this.radioButtonOriginal.Name = "radioButtonOriginal";
            this.radioButtonOriginal.Size = new System.Drawing.Size(60, 17);
            this.radioButtonOriginal.TabIndex = 21;
            this.radioButtonOriginal.TabStop = true;
            this.radioButtonOriginal.Text = "Original";
            this.radioButtonOriginal.UseVisualStyleBackColor = true;
            // 
            // radioButtonEroare
            // 
            this.radioButtonEroare.AutoSize = true;
            this.radioButtonEroare.Location = new System.Drawing.Point(16, 47);
            this.radioButtonEroare.Name = "radioButtonEroare";
            this.radioButtonEroare.Size = new System.Drawing.Size(56, 17);
            this.radioButtonEroare.TabIndex = 22;
            this.radioButtonEroare.Text = "Eroare";
            this.radioButtonEroare.UseVisualStyleBackColor = true;
            // 
            // radioButtonDecoded
            // 
            this.radioButtonDecoded.AutoSize = true;
            this.radioButtonDecoded.Location = new System.Drawing.Point(16, 70);
            this.radioButtonDecoded.Name = "radioButtonDecoded";
            this.radioButtonDecoded.Size = new System.Drawing.Size(69, 17);
            this.radioButtonDecoded.TabIndex = 23;
            this.radioButtonDecoded.Text = "Decoded";
            this.radioButtonDecoded.UseVisualStyleBackColor = true;
            // 
            // drawHistogrambutton
            // 
            this.drawHistogrambutton.Enabled = false;
            this.drawHistogrambutton.Location = new System.Drawing.Point(210, 432);
            this.drawHistogrambutton.Name = "drawHistogrambutton";
            this.drawHistogrambutton.Size = new System.Drawing.Size(95, 23);
            this.drawHistogrambutton.TabIndex = 26;
            this.drawHistogrambutton.Text = "Draw histogram";
            this.drawHistogrambutton.UseVisualStyleBackColor = true;
            this.drawHistogrambutton.Click += new System.EventHandler(this.buttonDrawHistogram_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonOriginal);
            this.groupBox1.Controls.Add(this.radioButtonEroare);
            this.groupBox1.Controls.Add(this.radioButtonDecoded);
            this.groupBox1.Location = new System.Drawing.Point(210, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 92);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton128);
            this.groupBox2.Controls.Add(this.radioButtonA);
            this.groupBox2.Controls.Add(this.radioButtonB);
            this.groupBox2.Controls.Add(this.radioButtonC);
            this.groupBox2.Controls.Add(this.radioButtonABC);
            this.groupBox2.Controls.Add(this.radioButtonJpegLS);
            this.groupBox2.Controls.Add(this.radioButtonABC2);
            this.groupBox2.Controls.Add(this.radioButtonAB2);
            this.groupBox2.Controls.Add(this.radioButtonBAC2);
            this.groupBox2.Location = new System.Drawing.Point(12, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 224);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // scaleNumericUpDown
            // 
            this.scaleNumericUpDown.DecimalPlaces = 2;
            this.scaleNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleNumericUpDown.Location = new System.Drawing.Point(386, 270);
            this.scaleNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.scaleNumericUpDown.Name = "scaleNumericUpDown";
            this.scaleNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.scaleNumericUpDown.TabIndex = 29;
            this.scaleNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // scaleHistogramNumericUpDown
            // 
            this.scaleHistogramNumericUpDown.DecimalPlaces = 2;
            this.scaleHistogramNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleHistogramNumericUpDown.Location = new System.Drawing.Point(220, 406);
            this.scaleHistogramNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.scaleHistogramNumericUpDown.Name = "scaleHistogramNumericUpDown";
            this.scaleHistogramNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.scaleHistogramNumericUpDown.TabIndex = 30;
            this.scaleHistogramNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Pre files | *.pre";
            // 
            // histogramPanel
            // 
            this.histogramPanel.AutoSize = true;
            this.histogramPanel.Location = new System.Drawing.Point(335, 290);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(600, 300);
            this.histogramPanel.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 665);
            this.Controls.Add(this.histogramPanel);
            this.Controls.Add(this.scaleHistogramNumericUpDown);
            this.Controls.Add(this.scaleNumericUpDown);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.drawHistogrambutton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.savePredictedButton);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.loadPredictedImageButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.predictButton);
            this.Controls.Add(this.loadOriginalButton);
            this.Controls.Add(this.predictedPictureBox);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.originalPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predictedPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHistogramNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox errorPictureBox;
        private System.Windows.Forms.PictureBox predictedPictureBox;
        private System.Windows.Forms.Button loadOriginalButton;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button savePredictedButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button loadPredictedImageButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.RadioButton radioButton128;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonAB2;
        private System.Windows.Forms.RadioButton radioButtonBAC2;
        private System.Windows.Forms.RadioButton radioButtonABC2;
        private System.Windows.Forms.RadioButton radioButtonABC;
        private System.Windows.Forms.RadioButton radioButtonJpegLS;
        private System.Windows.Forms.RadioButton radioButtonOriginal;
        private System.Windows.Forms.RadioButton radioButtonEroare;
        private System.Windows.Forms.RadioButton radioButtonDecoded;
        private System.Windows.Forms.Button drawHistogrambutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown scaleNumericUpDown;
        private System.Windows.Forms.NumericUpDown scaleHistogramNumericUpDown;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Panel histogramPanel;
    }
}

