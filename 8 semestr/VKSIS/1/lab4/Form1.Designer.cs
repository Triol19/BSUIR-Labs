namespace lab4
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
            this.comboBox_machine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_speed = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.initializeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label_machine = new System.Windows.Forms.Label();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_length = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Connect = new System.Windows.Forms.Button();
            this.ipTo = new System.Windows.Forms.TextBox();
            this.ipFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.router = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_machine
            // 
            this.comboBox_machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_machine.FormattingEnabled = true;
            this.comboBox_machine.Location = new System.Drawing.Point(12, 29);
            this.comboBox_machine.Name = "comboBox_machine";
            this.comboBox_machine.Size = new System.Drawing.Size(129, 21);
            this.comboBox_machine.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Комбинация портов для данного компьютера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Скорость передачи (бод)";
            // 
            // comboBox_speed
            // 
            this.comboBox_speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_speed.FormattingEnabled = true;
            this.comboBox_speed.Location = new System.Drawing.Point(12, 84);
            this.comboBox_speed.Name = "comboBox_speed";
            this.comboBox_speed.Size = new System.Drawing.Size(73, 21);
            this.comboBox_speed.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(238, 138);
            this.textBox1.TabIndex = 0;
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(12, 232);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(115, 23);
            this.initializeButton.TabIndex = 6;
            this.initializeButton.Text = "Открыть COM-порт";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_addr);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.initializeButton);
            this.groupBox1.Controls.Add(this.stopButton);
            this.groupBox1.Location = new System.Drawing.Point(266, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 274);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // textBox_addr
            // 
            this.textBox_addr.Location = new System.Drawing.Point(101, 44);
            this.textBox_addr.MaxLength = 3;
            this.textBox_addr.Name = "textBox_addr";
            this.textBox_addr.Size = new System.Drawing.Size(71, 20);
            this.textBox_addr.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Кому?";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(175, 232);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Закрыть";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(542, 87);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 12;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(542, 204);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label_machine
            // 
            this.label_machine.AutoSize = true;
            this.label_machine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_machine.Location = new System.Drawing.Point(223, 12);
            this.label_machine.Name = "label_machine";
            this.label_machine.Size = new System.Drawing.Size(0, 24);
            this.label_machine.TabIndex = 9;
            // 
            // textBox_info
            // 
            this.textBox_info.Location = new System.Drawing.Point(12, 194);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_info.Size = new System.Drawing.Size(234, 92);
            this.textBox_info.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(551, 269);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Вкл";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Статус передачи(консоль)";
            // 
            // comboBox_length
            // 
            this.comboBox_length.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_length.Enabled = false;
            this.comboBox_length.FormattingEnabled = true;
            this.comboBox_length.Location = new System.Drawing.Point(12, 134);
            this.comboBox_length.Name = "comboBox_length";
            this.comboBox_length.Size = new System.Drawing.Size(40, 21);
            this.comboBox_length.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Длина пакета";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Font = new System.Drawing.Font("Times New Roman", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_address.Location = new System.Drawing.Point(667, 28);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(0, 226);
            this.label_address.TabIndex = 16;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(690, 269);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(144, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Изменить бит для CRC";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Connect
            // 
            this.Connect.Enabled = false;
            this.Connect.Location = new System.Drawing.Point(705, 29);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 18;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ipTo
            // 
            this.ipTo.Location = new System.Drawing.Point(278, 297);
            this.ipTo.MaxLength = 3;
            this.ipTo.Name = "ipTo";
            this.ipTo.Size = new System.Drawing.Size(94, 20);
            this.ipTo.TabIndex = 19;
            this.ipTo.Text = "192.168.1.122";
            // 
            // ipFrom
            // 
            this.ipFrom.Location = new System.Drawing.Point(542, 297);
            this.ipFrom.MaxLength = 3;
            this.ipFrom.Name = "ipFrom";
            this.ipFrom.Size = new System.Drawing.Size(94, 20);
            this.ipFrom.TabIndex = 20;
            this.ipFrom.Text = "192.168.1.122";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ip to:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ip from:";
            // 
            // router
            // 
            this.router.AutoSize = true;
            this.router.Location = new System.Drawing.Point(608, 269);
            this.router.Name = "router";
            this.router.Size = new System.Drawing.Size(59, 17);
            this.router.TabIndex = 22;
            this.router.Text = "Router";
            this.router.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 329);
            this.Controls.Add(this.router);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ipFrom);
            this.Controls.Add(this.ipTo);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_length);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label_machine);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_machine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_speed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Bit - Staffing + CRC + Circle ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_machine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_speed;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label_machine;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox ipTo;
        private System.Windows.Forms.TextBox ipFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox router;
    }
}

