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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend19 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend20 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea21 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend21 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.originalGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Submit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FWTGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.IFWTGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointsCountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalGraphic)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FWTGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFWTGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // originalGraphic
            // 
            chartArea19.Name = "ChartArea1";
            this.originalGraphic.ChartAreas.Add(chartArea19);
            legend19.Name = "Legend1";
            this.originalGraphic.Legends.Add(legend19);
            this.originalGraphic.Location = new System.Drawing.Point(6, 46);
            this.originalGraphic.Name = "originalGraphic";
            series19.ChartArea = "ChartArea1";
            series19.Legend = "Legend1";
            series19.Name = "Series1";
            this.originalGraphic.Series.Add(series19);
            this.originalGraphic.Size = new System.Drawing.Size(299, 156);
            this.originalGraphic.TabIndex = 0;
            this.originalGraphic.Text = "functionGraphic";
            this.originalGraphic.Visible = false;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(24, 381);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 25);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FWTGraphic);
            this.groupBox1.Controls.Add(this.IFWTGraphic);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.originalGraphic);
            this.groupBox1.Controls.Add(this.pointsCountTextBox);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 450);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(464, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "IFWT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(464, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "FWT";
            // 
            // FWTGraphic
            // 
            chartArea20.Name = "ChartArea1";
            this.FWTGraphic.ChartAreas.Add(chartArea20);
            legend20.Name = "Legend1";
            this.FWTGraphic.Legends.Add(legend20);
            this.FWTGraphic.Location = new System.Drawing.Point(321, 46);
            this.FWTGraphic.Name = "FWTGraphic";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "Series1";
            this.FWTGraphic.Series.Add(series20);
            this.FWTGraphic.Size = new System.Drawing.Size(299, 156);
            this.FWTGraphic.TabIndex = 13;
            this.FWTGraphic.Text = "chart1";
            this.FWTGraphic.Visible = false;
            // 
            // IFWTGraphic
            // 
            chartArea21.Name = "ChartArea1";
            this.IFWTGraphic.ChartAreas.Add(chartArea21);
            legend21.Name = "Legend1";
            this.IFWTGraphic.Legends.Add(legend21);
            this.IFWTGraphic.Location = new System.Drawing.Point(321, 250);
            this.IFWTGraphic.Name = "IFWTGraphic";
            series21.ChartArea = "ChartArea1";
            series21.Legend = "Legend1";
            series21.Name = "Series1";
            this.IFWTGraphic.Series.Add(series21);
            this.IFWTGraphic.Size = new System.Drawing.Size(299, 156);
            this.IFWTGraphic.TabIndex = 1;
            this.IFWTGraphic.Text = "chart1";
            this.IFWTGraphic.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number:";
            // 
            // pointsCountTextBox
            // 
            this.pointsCountTextBox.Location = new System.Drawing.Point(115, 264);
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
            this.ClientSize = new System.Drawing.Size(654, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalGraphic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FWTGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFWTGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart originalGraphic;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pointsCountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart IFWTGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart FWTGraphic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}

