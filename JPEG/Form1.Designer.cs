namespace JPEG
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
            this.redonePictureBoxP = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.first3StepsButton = new System.Windows.Forms.Button();
            this.lastStepsButton = new System.Windows.Forms.Button();
            this.eroarePatraticaTextBox = new System.Windows.Forms.TextBox();
            this.SNRTextBox = new System.Windows.Forms.TextBox();
            this.eliminareCoeficientRadioButton = new System.Windows.Forms.RadioButton();
            this.matriceSimplaCalculataRadioButton = new System.Windows.Forms.RadioButton();
            this.factorCalitateRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.factorCalitateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.matriceSimplaCalculataNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.coeficientNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redonePictureBoxP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factorCalitateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matriceSimplaCalculataNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coeficientNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Location = new System.Drawing.Point(12, 12);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(256, 256);
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(301, 12);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(256, 256);
            this.errorPictureBox.TabIndex = 1;
            this.errorPictureBox.TabStop = false;
            // 
            // redonePictureBoxP
            // 
            this.redonePictureBoxP.Location = new System.Drawing.Point(583, 12);
            this.redonePictureBoxP.Name = "redonePictureBoxP";
            this.redonePictureBoxP.Size = new System.Drawing.Size(256, 256);
            this.redonePictureBoxP.TabIndex = 2;
            this.redonePictureBoxP.TabStop = false;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 273);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // first3StepsButton
            // 
            this.first3StepsButton.Location = new System.Drawing.Point(18, 425);
            this.first3StepsButton.Name = "first3StepsButton";
            this.first3StepsButton.Size = new System.Drawing.Size(104, 58);
            this.first3StepsButton.TabIndex = 5;
            this.first3StepsButton.Text = "1. Trans\r\n2. Sub\r\n3. DCT\r\n";
            this.first3StepsButton.UseVisualStyleBackColor = true;
            this.first3StepsButton.Click += new System.EventHandler(this.first3StepsButton_Click);
            // 
            // lastStepsButton
            // 
            this.lastStepsButton.Enabled = false;
            this.lastStepsButton.Location = new System.Drawing.Point(151, 425);
            this.lastStepsButton.Name = "lastStepsButton";
            this.lastStepsButton.Size = new System.Drawing.Size(104, 78);
            this.lastStepsButton.TabIndex = 6;
            this.lastStepsButton.Text = "4. Cuantizare\r\n5. iCuant\r\n6. IDCT\r\n7. ISub\r\n8. ITrans";
            this.lastStepsButton.UseVisualStyleBackColor = true;
            this.lastStepsButton.Click += new System.EventHandler(this.lastStepsButton_Click);
            // 
            // eroarePatraticaTextBox
            // 
            this.eroarePatraticaTextBox.Location = new System.Drawing.Point(301, 418);
            this.eroarePatraticaTextBox.Name = "eroarePatraticaTextBox";
            this.eroarePatraticaTextBox.Size = new System.Drawing.Size(375, 20);
            this.eroarePatraticaTextBox.TabIndex = 7;
            // 
            // SNRTextBox
            // 
            this.SNRTextBox.Location = new System.Drawing.Point(301, 445);
            this.SNRTextBox.Name = "SNRTextBox";
            this.SNRTextBox.Size = new System.Drawing.Size(375, 20);
            this.SNRTextBox.TabIndex = 8;
            // 
            // eliminareCoeficientRadioButton
            // 
            this.eliminareCoeficientRadioButton.AutoSize = true;
            this.eliminareCoeficientRadioButton.Checked = true;
            this.eliminareCoeficientRadioButton.Location = new System.Drawing.Point(6, 19);
            this.eliminareCoeficientRadioButton.Name = "eliminareCoeficientRadioButton";
            this.eliminareCoeficientRadioButton.Size = new System.Drawing.Size(118, 17);
            this.eliminareCoeficientRadioButton.TabIndex = 9;
            this.eliminareCoeficientRadioButton.TabStop = true;
            this.eliminareCoeficientRadioButton.Text = "Eliminare coeficienti";
            this.eliminareCoeficientRadioButton.UseVisualStyleBackColor = true;
            this.eliminareCoeficientRadioButton.CheckedChanged += new System.EventHandler(this.eliminareCoeficientRadioButton_CheckedChanged);
            // 
            // matriceSimplaCalculataRadioButton
            // 
            this.matriceSimplaCalculataRadioButton.AutoSize = true;
            this.matriceSimplaCalculataRadioButton.Location = new System.Drawing.Point(6, 43);
            this.matriceSimplaCalculataRadioButton.Name = "matriceSimplaCalculataRadioButton";
            this.matriceSimplaCalculataRadioButton.Size = new System.Drawing.Size(138, 17);
            this.matriceSimplaCalculataRadioButton.TabIndex = 10;
            this.matriceSimplaCalculataRadioButton.Text = "Matrice simpla calculata";
            this.matriceSimplaCalculataRadioButton.UseVisualStyleBackColor = true;
            this.matriceSimplaCalculataRadioButton.CheckedChanged += new System.EventHandler(this.matriceSimplaCalculataRadioButton_CheckedChanged);
            // 
            // factorCalitateRadioButton
            // 
            this.factorCalitateRadioButton.AutoSize = true;
            this.factorCalitateRadioButton.Location = new System.Drawing.Point(6, 66);
            this.factorCalitateRadioButton.Name = "factorCalitateRadioButton";
            this.factorCalitateRadioButton.Size = new System.Drawing.Size(137, 17);
            this.factorCalitateRadioButton.TabIndex = 11;
            this.factorCalitateRadioButton.Text = "Factor de calitate JPEG";
            this.factorCalitateRadioButton.UseVisualStyleBackColor = true;
            this.factorCalitateRadioButton.CheckedChanged += new System.EventHandler(this.factorCalitateRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.factorCalitateNumericUpDown);
            this.groupBox1.Controls.Add(this.matriceSimplaCalculataNumericUpDown);
            this.groupBox1.Controls.Add(this.coeficientNumericUpDown);
            this.groupBox1.Controls.Add(this.eliminareCoeficientRadioButton);
            this.groupBox1.Controls.Add(this.factorCalitateRadioButton);
            this.groupBox1.Controls.Add(this.matriceSimplaCalculataRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // factorCalitateNumericUpDown
            // 
            this.factorCalitateNumericUpDown.Location = new System.Drawing.Point(150, 66);
            this.factorCalitateNumericUpDown.Name = "factorCalitateNumericUpDown";
            this.factorCalitateNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.factorCalitateNumericUpDown.TabIndex = 16;
            this.factorCalitateNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // matriceSimplaCalculataNumericUpDown
            // 
            this.matriceSimplaCalculataNumericUpDown.Location = new System.Drawing.Point(150, 40);
            this.matriceSimplaCalculataNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.matriceSimplaCalculataNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.matriceSimplaCalculataNumericUpDown.Name = "matriceSimplaCalculataNumericUpDown";
            this.matriceSimplaCalculataNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.matriceSimplaCalculataNumericUpDown.TabIndex = 15;
            this.matriceSimplaCalculataNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // coeficientNumericUpDown
            // 
            this.coeficientNumericUpDown.Location = new System.Drawing.Point(150, 16);
            this.coeficientNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.coeficientNumericUpDown.Name = "coeficientNumericUpDown";
            this.coeficientNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.coeficientNumericUpDown.TabIndex = 13;
            this.coeficientNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // scaleNumericUpDown
            // 
            this.scaleNumericUpDown.DecimalPlaces = 2;
            this.scaleNumericUpDown.Location = new System.Drawing.Point(427, 276);
            this.scaleNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.scaleNumericUpDown.Name = "scaleNumericUpDown";
            this.scaleNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.scaleNumericUpDown.TabIndex = 14;
            this.scaleNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Eroare patratica";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(682, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Raport semnal zgomot (SNR)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scaleNumericUpDown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SNRTextBox);
            this.Controls.Add(this.eroarePatraticaTextBox);
            this.Controls.Add(this.lastStepsButton);
            this.Controls.Add(this.first3StepsButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.redonePictureBoxP);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.originalPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redonePictureBoxP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factorCalitateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matriceSimplaCalculataNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coeficientNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox errorPictureBox;
        private System.Windows.Forms.PictureBox redonePictureBoxP;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button first3StepsButton;
        private System.Windows.Forms.Button lastStepsButton;
        private System.Windows.Forms.TextBox eroarePatraticaTextBox;
        private System.Windows.Forms.TextBox SNRTextBox;
        private System.Windows.Forms.RadioButton eliminareCoeficientRadioButton;
        private System.Windows.Forms.RadioButton matriceSimplaCalculataRadioButton;
        private System.Windows.Forms.RadioButton factorCalitateRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown coeficientNumericUpDown;
        private System.Windows.Forms.NumericUpDown scaleNumericUpDown;
        private System.Windows.Forms.NumericUpDown matriceSimplaCalculataNumericUpDown;
        private System.Windows.Forms.NumericUpDown factorCalitateNumericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

