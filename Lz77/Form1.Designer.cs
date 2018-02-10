namespace Lz77
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
            this.BtnLoad = new System.Windows.Forms.Button();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.numericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.BtnEncode = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnLoadCompressed = new System.Windows.Forms.Button();
            this.textBoxCompressedInputFIle = new System.Windows.Forms.TextBox();
            this.openFileDialogCompressedFile = new System.Windows.Forms.OpenFileDialog();
            this.BtnDecode = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(12, 68);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(186, 23);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(13, 42);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(637, 20);
            this.textBoxInputFile.TabIndex = 2;
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(13, 23);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(74, 13);
            this.labelInputFile.TabIndex = 3;
            this.labelInputFile.Text = "Input file path:";
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(16, 100);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(35, 13);
            this.labelOffset.TabIndex = 4;
            this.labelOffset.Text = "Offset";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(16, 131);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(40, 13);
            this.labelLength.TabIndex = 5;
            this.labelLength.Text = "Length";
            // 
            // numericUpDownOffset
            // 
            this.numericUpDownOffset.Location = new System.Drawing.Point(62, 97);
            this.numericUpDownOffset.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownOffset.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownOffset.Name = "numericUpDownOffset";
            this.numericUpDownOffset.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownOffset.TabIndex = 6;
            this.numericUpDownOffset.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(62, 124);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownLength.TabIndex = 7;
            this.numericUpDownLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // BtnEncode
            // 
            this.BtnEncode.Location = new System.Drawing.Point(16, 166);
            this.BtnEncode.Name = "BtnEncode";
            this.BtnEncode.Size = new System.Drawing.Size(75, 23);
            this.BtnEncode.TabIndex = 8;
            this.BtnEncode.Text = "Encode";
            this.BtnEncode.UseVisualStyleBackColor = true;
            this.BtnEncode.Click += new System.EventHandler(this.BtnEncode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnLoadCompressed
            // 
            this.BtnLoadCompressed.Location = new System.Drawing.Point(12, 282);
            this.BtnLoadCompressed.Name = "BtnLoadCompressed";
            this.BtnLoadCompressed.Size = new System.Drawing.Size(186, 23);
            this.BtnLoadCompressed.TabIndex = 9;
            this.BtnLoadCompressed.Text = "Load compressed file";
            this.BtnLoadCompressed.UseVisualStyleBackColor = true;
            this.BtnLoadCompressed.Click += new System.EventHandler(this.BtnLoadCompressed_Click);
            // 
            // textBoxCompressedInputFIle
            // 
            this.textBoxCompressedInputFIle.Location = new System.Drawing.Point(12, 256);
            this.textBoxCompressedInputFIle.Name = "textBoxCompressedInputFIle";
            this.textBoxCompressedInputFIle.ReadOnly = true;
            this.textBoxCompressedInputFIle.Size = new System.Drawing.Size(638, 20);
            this.textBoxCompressedInputFIle.TabIndex = 10;
            // 
            // openFileDialogCompressedFile
            // 
            this.openFileDialogCompressedFile.FileName = "openFileDialogCompressedFile";
            this.openFileDialogCompressedFile.Filter = "Lz77 compressed files|*.lz77";
            // 
            // BtnDecode
            // 
            this.BtnDecode.Location = new System.Drawing.Point(19, 344);
            this.BtnDecode.Name = "BtnDecode";
            this.BtnDecode.Size = new System.Drawing.Size(75, 23);
            this.BtnDecode.TabIndex = 11;
            this.BtnDecode.Text = "Decode";
            this.BtnDecode.UseVisualStyleBackColor = true;
            this.BtnDecode.Click += new System.EventHandler(this.BtnDecode_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(687, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(233, 234);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 377);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnDecode);
            this.Controls.Add(this.textBoxCompressedInputFIle);
            this.Controls.Add(this.BtnLoadCompressed);
            this.Controls.Add(this.BtnEncode);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.numericUpDownOffset);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.labelInputFile);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.BtnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.NumericUpDown numericUpDownOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Button BtnEncode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnLoadCompressed;
        private System.Windows.Forms.TextBox textBoxCompressedInputFIle;
        private System.Windows.Forms.OpenFileDialog openFileDialogCompressedFile;
        private System.Windows.Forms.Button BtnDecode;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

