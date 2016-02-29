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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea78 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend78 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series78 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea79 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend79 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series79 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea80 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend80 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series80 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea81 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend81 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series81 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea82 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend82 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series82 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea83 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend83 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series83 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea84 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend84 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series84 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.originalYGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Submit = new System.Windows.Forms.Button();
            this.convolutionGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.convolutionFFTGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.correlationFFTGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.correlationGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.originalY2Graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.originalZGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConLabel = new System.Windows.Forms.Label();
            this.FFTConLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointsCountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalYGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.convolutionGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.convolutionFFTGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correlationFFTGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correlationGraphic)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalY2Graphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalZGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // originalYGraphic
            // 
            chartArea78.Name = "ChartArea1";
            this.originalYGraphic.ChartAreas.Add(chartArea78);
            legend78.Name = "Legend1";
            this.originalYGraphic.Legends.Add(legend78);
            this.originalYGraphic.Location = new System.Drawing.Point(6, 46);
            this.originalYGraphic.Name = "originalYGraphic";
            series78.ChartArea = "ChartArea1";
            series78.Legend = "Legend1";
            series78.Name = "Series1";
            this.originalYGraphic.Series.Add(series78);
            this.originalYGraphic.Size = new System.Drawing.Size(299, 156);
            this.originalYGraphic.TabIndex = 0;
            this.originalYGraphic.Text = "functionGraphic";
            this.originalYGraphic.Visible = false;
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
            // convolutionGraphic
            // 
            chartArea79.Name = "ChartArea1";
            this.convolutionGraphic.ChartAreas.Add(chartArea79);
            legend79.Name = "Legend1";
            this.convolutionGraphic.Legends.Add(legend79);
            this.convolutionGraphic.Location = new System.Drawing.Point(646, 46);
            this.convolutionGraphic.Name = "convolutionGraphic";
            series79.ChartArea = "ChartArea1";
            series79.Legend = "Legend1";
            series79.Name = "Series1";
            this.convolutionGraphic.Series.Add(series79);
            this.convolutionGraphic.Size = new System.Drawing.Size(299, 156);
            this.convolutionGraphic.TabIndex = 2;
            this.convolutionGraphic.Text = "chart1";
            this.convolutionGraphic.Visible = false;
            // 
            // convolutionFFTGraphic
            // 
            chartArea80.Name = "ChartArea1";
            this.convolutionFFTGraphic.ChartAreas.Add(chartArea80);
            legend80.Name = "Legend1";
            this.convolutionFFTGraphic.Legends.Add(legend80);
            this.convolutionFFTGraphic.Location = new System.Drawing.Point(974, 46);
            this.convolutionFFTGraphic.Name = "convolutionFFTGraphic";
            series80.ChartArea = "ChartArea1";
            series80.Legend = "Legend1";
            series80.Name = "Series1";
            this.convolutionFFTGraphic.Series.Add(series80);
            this.convolutionFFTGraphic.Size = new System.Drawing.Size(299, 155);
            this.convolutionFFTGraphic.TabIndex = 4;
            this.convolutionFFTGraphic.Text = "chart1";
            this.convolutionFFTGraphic.Visible = false;
            // 
            // correlationFFTGraphic
            // 
            chartArea81.Name = "ChartArea1";
            this.correlationFFTGraphic.ChartAreas.Add(chartArea81);
            legend81.Name = "Legend1";
            this.correlationFFTGraphic.Legends.Add(legend81);
            this.correlationFFTGraphic.Location = new System.Drawing.Point(974, 250);
            this.correlationFFTGraphic.Name = "correlationFFTGraphic";
            series81.ChartArea = "ChartArea1";
            series81.Legend = "Legend1";
            series81.Name = "Series1";
            this.correlationFFTGraphic.Series.Add(series81);
            this.correlationFFTGraphic.Size = new System.Drawing.Size(299, 156);
            this.correlationFFTGraphic.TabIndex = 5;
            this.correlationFFTGraphic.Text = "chart1";
            this.correlationFFTGraphic.Visible = false;
            // 
            // correlationGraphic
            // 
            chartArea82.Name = "ChartArea1";
            this.correlationGraphic.ChartAreas.Add(chartArea82);
            legend82.Name = "Legend1";
            this.correlationGraphic.Legends.Add(legend82);
            this.correlationGraphic.Location = new System.Drawing.Point(646, 250);
            this.correlationGraphic.Name = "correlationGraphic";
            series82.ChartArea = "ChartArea1";
            series82.Legend = "Legend1";
            series82.Name = "Series1";
            this.correlationGraphic.Series.Add(series82);
            this.correlationGraphic.Size = new System.Drawing.Size(299, 156);
            this.correlationGraphic.TabIndex = 5;
            this.correlationGraphic.Text = "chart1";
            this.correlationGraphic.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.originalY2Graphic);
            this.groupBox1.Controls.Add(this.originalZGraphic);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.correlationFFTGraphic);
            this.groupBox1.Controls.Add(this.ConLabel);
            this.groupBox1.Controls.Add(this.convolutionFFTGraphic);
            this.groupBox1.Controls.Add(this.correlationGraphic);
            this.groupBox1.Controls.Add(this.convolutionGraphic);
            this.groupBox1.Controls.Add(this.FFTConLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.originalYGraphic);
            this.groupBox1.Controls.Add(this.pointsCountTextBox);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1300, 450);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(425, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "z(x)=sin(5x)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(425, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "y(x)=cos(2x)";
            // 
            // originalY2Graphic
            // 
            chartArea83.Name = "ChartArea1";
            this.originalY2Graphic.ChartAreas.Add(chartArea83);
            legend83.Name = "Legend1";
            this.originalY2Graphic.Legends.Add(legend83);
            this.originalY2Graphic.Location = new System.Drawing.Point(321, 46);
            this.originalY2Graphic.Name = "originalY2Graphic";
            series83.ChartArea = "ChartArea1";
            series83.Legend = "Legend1";
            series83.Name = "Series1";
            this.originalY2Graphic.Series.Add(series83);
            this.originalY2Graphic.Size = new System.Drawing.Size(299, 156);
            this.originalY2Graphic.TabIndex = 13;
            this.originalY2Graphic.Text = "chart1";
            this.originalY2Graphic.Visible = false;
            // 
            // originalZGraphic
            // 
            chartArea84.Name = "ChartArea1";
            this.originalZGraphic.ChartAreas.Add(chartArea84);
            legend84.Name = "Legend1";
            this.originalZGraphic.Legends.Add(legend84);
            this.originalZGraphic.Location = new System.Drawing.Point(321, 250);
            this.originalZGraphic.Name = "originalZGraphic";
            series84.ChartArea = "ChartArea1";
            series84.Legend = "Legend1";
            series84.Name = "Series1";
            this.originalZGraphic.Series.Add(series84);
            this.originalZGraphic.Size = new System.Drawing.Size(299, 156);
            this.originalZGraphic.TabIndex = 1;
            this.originalZGraphic.Text = "chart1";
            this.originalZGraphic.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(1051, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cor f(x) and z(x) FFT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(1051, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Conv f(x) and y(x) FFT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(743, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Conv f(x) and y(x)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(743, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cor f(x) and z(x)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(84, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "f(x)=cos(2x)+sin(5x)";
            // 
            // ConLabel
            // 
            this.ConLabel.AutoSize = true;
            this.ConLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ConLabel.Location = new System.Drawing.Point(20, 250);
            this.ConLabel.Name = "ConLabel";
            this.ConLabel.Size = new System.Drawing.Size(20, 24);
            this.ConLabel.TabIndex = 7;
            this.ConLabel.Text = "0";
            this.ConLabel.Visible = false;
            // 
            // FFTConLabel
            // 
            this.FFTConLabel.AutoSize = true;
            this.FFTConLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FFTConLabel.Location = new System.Drawing.Point(20, 304);
            this.FFTConLabel.Name = "FFTConLabel";
            this.FFTConLabel.Size = new System.Drawing.Size(20, 24);
            this.FFTConLabel.TabIndex = 5;
            this.FFTConLabel.Text = "0";
            this.FFTConLabel.Visible = false;
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
            this.pointsCountTextBox.Text = "8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalYGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.convolutionGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.convolutionFFTGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correlationFFTGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correlationGraphic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalY2Graphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalZGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart originalYGraphic;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.DataVisualization.Charting.Chart convolutionGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart convolutionFFTGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart correlationFFTGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart correlationGraphic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pointsCountTextBox;
        private System.Windows.Forms.Label ConLabel;
        private System.Windows.Forms.Label FFTConLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart originalZGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart originalY2Graphic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}

