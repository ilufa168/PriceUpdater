namespace PriceUpdater
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
            this.TB_PCN_NO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bSelectFile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_PCN_NO
            // 
            this.TB_PCN_NO.Location = new System.Drawing.Point(74, 118);
            this.TB_PCN_NO.Name = "TB_PCN_NO";
            this.TB_PCN_NO.Size = new System.Drawing.Size(179, 20);
            this.TB_PCN_NO.TabIndex = 0;
            this.TB_PCN_NO.Text = "045/J/VIII/2018";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PCN No";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 72);
            this.button1.TabIndex = 2;
            this.button1.Text = "Just UPDATE IT ALREADY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select Price Update File";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 325);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 3;
            // 
            // bSelectFile
            // 
            this.bSelectFile.Location = new System.Drawing.Point(279, 321);
            this.bSelectFile.Name = "bSelectFile";
            this.bSelectFile.Size = new System.Drawing.Size(107, 23);
            this.bSelectFile.TabIndex = 4;
            this.bSelectFile.Text = "Browse";
            this.bSelectFile.UseVisualStyleBackColor = true;
            this.bSelectFile.Click += new System.EventHandler(this.bSelectFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "Update From File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bSelectFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_PCN_NO);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_PCN_NO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bSelectFile;
        private System.Windows.Forms.Button button2;
    }
}

