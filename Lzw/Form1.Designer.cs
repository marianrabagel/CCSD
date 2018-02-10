namespace Lzw
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelInputFIle = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFreeze = new System.Windows.Forms.CheckBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.textBoxCompressFilePath = new System.Windows.Forms.TextBox();
            this.buttonLoadDecompressFile = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonDecompress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(11, 54);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(11, 28);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(667, 20);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelInputFIle
            // 
            this.labelInputFIle.AutoSize = true;
            this.labelInputFIle.Location = new System.Drawing.Point(12, 9);
            this.labelInputFIle.Name = "labelInputFIle";
            this.labelInputFIle.Size = new System.Drawing.Size(47, 13);
            this.labelInputFIle.TabIndex = 2;
            this.labelInputFIle.Text = "Input file";
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(15, 94);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(33, 13);
            this.labelIndex.TabIndex = 3;
            this.labelIndex.Text = "Index";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(55, 94);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // checkBoxFreeze
            // 
            this.checkBoxFreeze.AutoSize = true;
            this.checkBoxFreeze.Checked = true;
            this.checkBoxFreeze.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFreeze.Location = new System.Drawing.Point(124, 97);
            this.checkBoxFreeze.Name = "checkBoxFreeze";
            this.checkBoxFreeze.Size = new System.Drawing.Size(58, 17);
            this.checkBoxFreeze.TabIndex = 5;
            this.checkBoxFreeze.Text = "Freeze";
            this.checkBoxFreeze.UseVisualStyleBackColor = true;
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(11, 132);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 6;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // textBoxCompressFilePath
            // 
            this.textBoxCompressFilePath.Location = new System.Drawing.Point(11, 186);
            this.textBoxCompressFilePath.Name = "textBoxCompressFilePath";
            this.textBoxCompressFilePath.ReadOnly = true;
            this.textBoxCompressFilePath.Size = new System.Drawing.Size(667, 20);
            this.textBoxCompressFilePath.TabIndex = 7;
            // 
            // buttonLoadDecompressFile
            // 
            this.buttonLoadDecompressFile.Location = new System.Drawing.Point(11, 212);
            this.buttonLoadDecompressFile.Name = "buttonLoadDecompressFile";
            this.buttonLoadDecompressFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadDecompressFile.TabIndex = 8;
            this.buttonLoadDecompressFile.Text = "Load";
            this.buttonLoadDecompressFile.UseVisualStyleBackColor = true;
            this.buttonLoadDecompressFile.Click += new System.EventHandler(this.buttonLoadDecompressFile_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialogCompressFile";
            this.openFileDialog2.Filter = "Lzw compressed files | *.lzw";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(684, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(173, 238);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // buttonDecompress
            // 
            this.buttonDecompress.Location = new System.Drawing.Point(11, 258);
            this.buttonDecompress.Name = "buttonDecompress";
            this.buttonDecompress.Size = new System.Drawing.Size(75, 23);
            this.buttonDecompress.TabIndex = 10;
            this.buttonDecompress.Text = "Decompress";
            this.buttonDecompress.UseVisualStyleBackColor = true;
            this.buttonDecompress.Click += new System.EventHandler(this.buttonDecompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 283);
            this.Controls.Add(this.buttonDecompress);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonLoadDecompressFile);
            this.Controls.Add(this.textBoxCompressFilePath);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.checkBoxFreeze);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.labelInputFIle);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.BtnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelInputFIle;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBoxFreeze;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.TextBox textBoxCompressFilePath;
        private System.Windows.Forms.Button buttonLoadDecompressFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonDecompress;
    }
}

