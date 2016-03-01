namespace CosLab1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_Clust = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox_kernel = new System.Windows.Forms.TextBox();
            this.label_objects = new System.Windows.Forms.Label();
            this.useMedian = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox_treshold = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 358);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(550, 47);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Median filter + to gray tone";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(550, 84);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Binarization";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(550, 245);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Refresh image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(550, 280);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 30);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(550, 120);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(192, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "Clasterization";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox_Clust
            // 
            this.textBox_Clust.Location = new System.Drawing.Point(651, 162);
            this.textBox_Clust.Name = "textBox_Clust";
            this.textBox_Clust.Size = new System.Drawing.Size(30, 20);
            this.textBox_Clust.TabIndex = 6;
            this.textBox_Clust.Text = "2";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(473, 345);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Open Image";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox_kernel
            // 
            this.textBox_kernel.Location = new System.Drawing.Point(651, 189);
            this.textBox_kernel.Name = "textBox_kernel";
            this.textBox_kernel.Size = new System.Drawing.Size(30, 20);
            this.textBox_kernel.TabIndex = 8;
            this.textBox_kernel.Text = "3";
            // 
            // label_objects
            // 
            this.label_objects.AutoSize = true;
            this.label_objects.Location = new System.Drawing.Point(703, 355);
            this.label_objects.Name = "label_objects";
            this.label_objects.Size = new System.Drawing.Size(29, 13);
            this.label_objects.TabIndex = 9;
            this.label_objects.Text = "NaN";
            // 
            // useMedian
            // 
            this.useMedian.AutoSize = true;
            this.useMedian.Location = new System.Drawing.Point(550, 215);
            this.useMedian.Name = "useMedian";
            this.useMedian.Size = new System.Drawing.Size(111, 17);
            this.useMedian.TabIndex = 10;
            this.useMedian.Text = "Use median filter?";
            this.useMedian.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number of objects:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Number of clasters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kerner size:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(473, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Adaptive binarization";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox_treshold
            // 
            this.textBox_treshold.Location = new System.Drawing.Point(747, 91);
            this.textBox_treshold.Name = "textBox_treshold";
            this.textBox_treshold.Size = new System.Drawing.Size(30, 20);
            this.textBox_treshold.TabIndex = 15;
            this.textBox_treshold.Text = "128";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(748, 245);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(192, 30);
            this.button8.TabIndex = 16;
            this.button8.Text = "Min filter";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(747, 280);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(192, 30);
            this.button9.TabIndex = 17;
            this.button9.Text = "Max filter";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 377);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox_treshold);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useMedian);
            this.Controls.Add(this.label_objects);
            this.Controls.Add(this.textBox_kernel);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox_Clust);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Clasterization";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_Clust;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox_kernel;
        private System.Windows.Forms.Label label_objects;
        private System.Windows.Forms.CheckBox useMedian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox_treshold;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

