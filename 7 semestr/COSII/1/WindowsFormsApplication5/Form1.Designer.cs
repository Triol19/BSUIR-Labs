namespace WindowsFormsApplication5
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.originalGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Submit = new System.Windows.Forms.Button();
            this.magnitudeGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inverseGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fastInverseGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fastMagnitudeGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DFTLabel = new System.Windows.Forms.Label();
            this.FFTLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointsCountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnitudeGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inverseGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastInverseGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastMagnitudeGraphic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalGraphic
            // 
            chartArea1.Name = "ChartArea1";
            this.originalGraphic.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.originalGraphic.Legends.Add(legend1);
            this.originalGraphic.Location = new System.Drawing.Point(24, 28);
            this.originalGraphic.Name = "originalGraphic";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.originalGraphic.Series.Add(series1);
            this.originalGraphic.Size = new System.Drawing.Size(299, 156);
            this.originalGraphic.TabIndex = 0;
            this.originalGraphic.Text = "functionGraphic";
            this.originalGraphic.Visible = false;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(24, 392);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 25);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // magnitudeGraphic
            // 
            chartArea2.Name = "ChartArea1";
            this.magnitudeGraphic.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.magnitudeGraphic.Legends.Add(legend2);
            this.magnitudeGraphic.Location = new System.Drawing.Point(361, 28);
            this.magnitudeGraphic.Name = "magnitudeGraphic";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.magnitudeGraphic.Series.Add(series2);
            this.magnitudeGraphic.Size = new System.Drawing.Size(299, 156);
            this.magnitudeGraphic.TabIndex = 2;
            this.magnitudeGraphic.Text = "chart1";
            this.magnitudeGraphic.Visible = false;
            // 
            // inverseGraphic
            // 
            chartArea3.Name = "ChartArea1";
            this.inverseGraphic.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.inverseGraphic.Legends.Add(legend3);
            this.inverseGraphic.Location = new System.Drawing.Point(700, 28);
            this.inverseGraphic.Name = "inverseGraphic";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.inverseGraphic.Series.Add(series3);
            this.inverseGraphic.Size = new System.Drawing.Size(299, 155);
            this.inverseGraphic.TabIndex = 4;
            this.inverseGraphic.Text = "chart1";
            this.inverseGraphic.Visible = false;
            // 
            // fastInverseGraphic
            // 
            chartArea4.Name = "ChartArea1";
            this.fastInverseGraphic.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.fastInverseGraphic.Legends.Add(legend4);
            this.fastInverseGraphic.Location = new System.Drawing.Point(700, 250);
            this.fastInverseGraphic.Name = "fastInverseGraphic";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.fastInverseGraphic.Series.Add(series4);
            this.fastInverseGraphic.Size = new System.Drawing.Size(299, 156);
            this.fastInverseGraphic.TabIndex = 5;
            this.fastInverseGraphic.Text = "chart1";
            this.fastInverseGraphic.Visible = false;
            // 
            // fastMagnitudeGraphic
            // 
            chartArea5.Name = "ChartArea1";
            this.fastMagnitudeGraphic.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.fastMagnitudeGraphic.Legends.Add(legend5);
            this.fastMagnitudeGraphic.Location = new System.Drawing.Point(361, 250);
            this.fastMagnitudeGraphic.Name = "fastMagnitudeGraphic";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.fastMagnitudeGraphic.Series.Add(series5);
            this.fastMagnitudeGraphic.Size = new System.Drawing.Size(299, 156);
            this.fastMagnitudeGraphic.TabIndex = 5;
            this.fastMagnitudeGraphic.Text = "chart1";
            this.fastMagnitudeGraphic.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fastInverseGraphic);
            this.groupBox1.Controls.Add(this.DFTLabel);
            this.groupBox1.Controls.Add(this.inverseGraphic);
            this.groupBox1.Controls.Add(this.fastMagnitudeGraphic);
            this.groupBox1.Controls.Add(this.magnitudeGraphic);
            this.groupBox1.Controls.Add(this.FFTLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.originalGraphic);
            this.groupBox1.Controls.Add(this.pointsCountTextBox);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1046, 450);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(833, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "IFFT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(833, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "IDFT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(469, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "DFT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(469, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "FFT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(100, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "f(x)=cos(2x)+sin(5x)";
            // 
            // DFTLabel
            // 
            this.DFTLabel.AutoSize = true;
            this.DFTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DFTLabel.Location = new System.Drawing.Point(20, 250);
            this.DFTLabel.Name = "DFTLabel";
            this.DFTLabel.Size = new System.Drawing.Size(20, 24);
            this.DFTLabel.TabIndex = 7;
            this.DFTLabel.Text = "0";
            this.DFTLabel.Visible = false;
            // 
            // FFTLabel
            // 
            this.FFTLabel.AutoSize = true;
            this.FFTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FFTLabel.Location = new System.Drawing.Point(20, 304);
            this.FFTLabel.Name = "FFTLabel";
            this.FFTLabel.Size = new System.Drawing.Size(20, 24);
            this.FFTLabel.TabIndex = 5;
            this.FFTLabel.Text = "0";
            this.FFTLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number:";
            // 
            // pointsCountTextBox
            // 
            this.pointsCountTextBox.Location = new System.Drawing.Point(117, 354);
            this.pointsCountTextBox.Name = "pointsCountTextBox";
            this.pointsCountTextBox.ReadOnly = true;
            this.pointsCountTextBox.Size = new System.Drawing.Size(33, 20);
            this.pointsCountTextBox.TabIndex = 2;
            this.pointsCountTextBox.Text = "32";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnitudeGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inverseGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastInverseGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastMagnitudeGraphic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart originalGraphic;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.DataVisualization.Charting.Chart magnitudeGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart inverseGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart fastInverseGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart fastMagnitudeGraphic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pointsCountTextBox;
        private System.Windows.Forms.Label DFTLabel;
        private System.Windows.Forms.Label FFTLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}

