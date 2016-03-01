namespace CosLab2
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
            this.firstLetterPictureBox = new System.Windows.Forms.PictureBox();
            this.secondLetterPictureBox = new System.Windows.Forms.PictureBox();
            this.thirdLetterPictureBox = new System.Windows.Forms.PictureBox();
            this.differenceButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clearImageButton = new System.Windows.Forms.Button();
            this.noiseTextBox = new System.Windows.Forms.TextBox();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.noiseButton = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.afterPictureBox = new System.Windows.Forms.PictureBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.beforePictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.teachButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.firstLetterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondLetterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdLetterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstLetterPictureBox
            // 
            this.firstLetterPictureBox.Location = new System.Drawing.Point(14, 16);
            this.firstLetterPictureBox.Name = "firstLetterPictureBox";
            this.firstLetterPictureBox.Size = new System.Drawing.Size(326, 326);
            this.firstLetterPictureBox.TabIndex = 0;
            this.firstLetterPictureBox.TabStop = false;
            this.firstLetterPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.firstLetterPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // secondLetterPictureBox
            // 
            this.secondLetterPictureBox.Location = new System.Drawing.Point(427, 16);
            this.secondLetterPictureBox.Name = "secondLetterPictureBox";
            this.secondLetterPictureBox.Size = new System.Drawing.Size(326, 326);
            this.secondLetterPictureBox.TabIndex = 1;
            this.secondLetterPictureBox.TabStop = false;
            this.secondLetterPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.secondLetterPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // thirdLetterPictureBox
            // 
            this.thirdLetterPictureBox.Location = new System.Drawing.Point(843, 16);
            this.thirdLetterPictureBox.Name = "thirdLetterPictureBox";
            this.thirdLetterPictureBox.Size = new System.Drawing.Size(326, 326);
            this.thirdLetterPictureBox.TabIndex = 1;
            this.thirdLetterPictureBox.TabStop = false;
            this.thirdLetterPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseClick);
            this.thirdLetterPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // differenceButton
            // 
            this.differenceButton.Enabled = false;
            this.differenceButton.Location = new System.Drawing.Point(898, 422);
            this.differenceButton.Name = "differenceButton";
            this.differenceButton.Size = new System.Drawing.Size(255, 54);
            this.differenceButton.TabIndex = 7;
            this.differenceButton.Text = "Распознать";
            this.differenceButton.UseVisualStyleBackColor = true;
            this.differenceButton.Click += new System.EventHandler(this.differenceButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "После";
            // 
            // clearImageButton
            // 
            this.clearImageButton.Location = new System.Drawing.Point(737, 241);
            this.clearImageButton.Name = "clearImageButton";
            this.clearImageButton.Size = new System.Drawing.Size(150, 23);
            this.clearImageButton.TabIndex = 7;
            this.clearImageButton.Text = "Очистить";
            this.clearImageButton.UseVisualStyleBackColor = true;
            this.clearImageButton.Click += new System.EventHandler(this.clearImageButton_Click);
            // 
            // noiseTextBox
            // 
            this.noiseTextBox.Location = new System.Drawing.Point(970, 243);
            this.noiseTextBox.MaxLength = 3;
            this.noiseTextBox.Name = "noiseTextBox";
            this.noiseTextBox.Size = new System.Drawing.Size(100, 20);
            this.noiseTextBox.TabIndex = 5;
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(737, 270);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(150, 23);
            this.clearAllButton.TabIndex = 8;
            this.clearAllButton.Text = "Очистить все";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(916, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Шум % :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(737, 153);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Буква 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // noiseButton
            // 
            this.noiseButton.Enabled = false;
            this.noiseButton.Location = new System.Drawing.Point(919, 270);
            this.noiseButton.Name = "noiseButton";
            this.noiseButton.Size = new System.Drawing.Size(151, 23);
            this.noiseButton.TabIndex = 3;
            this.noiseButton.Text = "Применить";
            this.noiseButton.UseVisualStyleBackColor = true;
            this.noiseButton.Click += new System.EventHandler(this.noiseButton_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(737, 176);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Буква 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // afterPictureBox
            // 
            this.afterPictureBox.Location = new System.Drawing.Point(385, 78);
            this.afterPictureBox.Name = "afterPictureBox";
            this.afterPictureBox.Size = new System.Drawing.Size(326, 326);
            this.afterPictureBox.TabIndex = 1;
            this.afterPictureBox.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(737, 199);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(64, 17);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Буква 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // beforePictureBox
            // 
            this.beforePictureBox.Location = new System.Drawing.Point(14, 78);
            this.beforePictureBox.Name = "beforePictureBox";
            this.beforePictureBox.Size = new System.Drawing.Size(326, 326);
            this.beforePictureBox.TabIndex = 1;
            this.beforePictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "До";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(759, 15);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(673, 15);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(80, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(579, 20);
            this.textBox2.TabIndex = 5;
            // 
            // teachButton
            // 
            this.teachButton.Enabled = false;
            this.teachButton.Location = new System.Drawing.Point(843, 15);
            this.teachButton.Name = "teachButton";
            this.teachButton.Size = new System.Drawing.Size(113, 23);
            this.teachButton.TabIndex = 2;
            this.teachButton.Text = "Обучить НС";
            this.teachButton.UseVisualStyleBackColor = true;
            this.teachButton.Click += new System.EventHandler(this.teachButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-2, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.firstLetterPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.secondLetterPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.thirdLetterPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.beforePictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.teachButton);
            this.splitContainer1.Panel2.Controls.Add(this.radioButton3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.openButton);
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.afterPictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel2.Controls.Add(this.noiseButton);
            this.splitContainer1.Panel2.Controls.Add(this.radioButton1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.clearAllButton);
            this.splitContainer1.Panel2.Controls.Add(this.noiseTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.clearImageButton);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.differenceButton);
            this.splitContainer1.Size = new System.Drawing.Size(1195, 860);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 884);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Нейронная сеть Хопфилда";
            ((System.ComponentModel.ISupportInitialize)(this.firstLetterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondLetterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdLetterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforePictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox firstLetterPictureBox;
        private System.Windows.Forms.PictureBox secondLetterPictureBox;
        private System.Windows.Forms.PictureBox thirdLetterPictureBox;
        private System.Windows.Forms.Button differenceButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearImageButton;
        private System.Windows.Forms.TextBox noiseTextBox;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button noiseButton;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox afterPictureBox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.PictureBox beforePictureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button teachButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}