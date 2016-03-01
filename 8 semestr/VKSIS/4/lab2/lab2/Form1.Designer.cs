namespace lab2
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
            this.port1TextBox = new System.Windows.Forms.TextBox();
            this.port2TextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.monitorCheckBox = new System.Windows.Forms.CheckBox();
            this.prioComboBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.monitorLabel = new System.Windows.Forms.Label();
            this.wantToSendLabel = new System.Windows.Forms.Label();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.destTextBox = new System.Windows.Forms.TextBox();
            this.receiveTextBox = new System.Windows.Forms.TextBox();
            this.sendMarkerButton = new System.Windows.Forms.Button();
            this.ipTo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.infiniteCheckBox = new System.Windows.Forms.CheckBox();
            this.withoutPriorCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // port1TextBox
            // 
            this.port1TextBox.Location = new System.Drawing.Point(12, 14);
            this.port1TextBox.Name = "port1TextBox";
            this.port1TextBox.Size = new System.Drawing.Size(80, 20);
            this.port1TextBox.TabIndex = 0;
            this.port1TextBox.Text = "5555";
            // 
            // port2TextBox
            // 
            this.port2TextBox.Location = new System.Drawing.Point(98, 14);
            this.port2TextBox.Name = "port2TextBox";
            this.port2TextBox.Size = new System.Drawing.Size(80, 20);
            this.port2TextBox.TabIndex = 1;
            this.port2TextBox.Text = "5556";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(98, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(80, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "MAC111";
            // 
            // monitorCheckBox
            // 
            this.monitorCheckBox.AutoSize = true;
            this.monitorCheckBox.Location = new System.Drawing.Point(16, 44);
            this.monitorCheckBox.Name = "monitorCheckBox";
            this.monitorCheckBox.Size = new System.Drawing.Size(62, 17);
            this.monitorCheckBox.TabIndex = 3;
            this.monitorCheckBox.Text = "Monitor";
            this.monitorCheckBox.UseVisualStyleBackColor = true;
            // 
            // prioComboBox
            // 
            this.prioComboBox.DisplayMember = "1";
            this.prioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prioComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.prioComboBox.Location = new System.Drawing.Point(184, 13);
            this.prioComboBox.Name = "prioComboBox";
            this.prioComboBox.Size = new System.Drawing.Size(88, 21);
            this.prioComboBox.TabIndex = 4;
            this.prioComboBox.Tag = "";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(185, 41);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(87, 23);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // monitorLabel
            // 
            this.monitorLabel.AutoSize = true;
            this.monitorLabel.Location = new System.Drawing.Point(23, 76);
            this.monitorLabel.Name = "monitorLabel";
            this.monitorLabel.Size = new System.Drawing.Size(0, 13);
            this.monitorLabel.TabIndex = 6;
            // 
            // wantToSendLabel
            // 
            this.wantToSendLabel.AutoSize = true;
            this.wantToSendLabel.Location = new System.Drawing.Point(114, 76);
            this.wantToSendLabel.Name = "wantToSendLabel";
            this.wantToSendLabel.Size = new System.Drawing.Size(0, 13);
            this.wantToSendLabel.TabIndex = 7;
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(16, 143);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(257, 80);
            this.sendTextBox.TabIndex = 8;
            this.sendTextBox.Text = "<Data to send>";
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(118, 227);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 9;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // destTextBox
            // 
            this.destTextBox.Location = new System.Drawing.Point(15, 229);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.Size = new System.Drawing.Size(99, 20);
            this.destTextBox.TabIndex = 10;
            this.destTextBox.Text = "MAC112";
            // 
            // receiveTextBox
            // 
            this.receiveTextBox.Location = new System.Drawing.Point(12, 274);
            this.receiveTextBox.Multiline = true;
            this.receiveTextBox.Name = "receiveTextBox";
            this.receiveTextBox.ReadOnly = true;
            this.receiveTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveTextBox.Size = new System.Drawing.Size(257, 106);
            this.receiveTextBox.TabIndex = 11;
            this.receiveTextBox.Text = "Received log:";
            // 
            // sendMarkerButton
            // 
            this.sendMarkerButton.Enabled = false;
            this.sendMarkerButton.Location = new System.Drawing.Point(197, 227);
            this.sendMarkerButton.Name = "sendMarkerButton";
            this.sendMarkerButton.Size = new System.Drawing.Size(75, 23);
            this.sendMarkerButton.TabIndex = 12;
            this.sendMarkerButton.Text = "Marker";
            this.sendMarkerButton.UseVisualStyleBackColor = true;
            this.sendMarkerButton.Click += new System.EventHandler(this.sendMarkerButton_Click);
            // 
            // ipTo
            // 
            this.ipTo.Location = new System.Drawing.Point(12, 79);
            this.ipTo.Name = "ipTo";
            this.ipTo.Size = new System.Drawing.Size(80, 20);
            this.ipTo.TabIndex = 13;
            this.ipTo.Text = "192.168.1.8";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Initialize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infiniteCheckBox
            // 
            this.infiniteCheckBox.AutoSize = true;
            this.infiniteCheckBox.Checked = true;
            this.infiniteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.infiniteCheckBox.Location = new System.Drawing.Point(196, 112);
            this.infiniteCheckBox.Name = "infiniteCheckBox";
            this.infiniteCheckBox.Size = new System.Drawing.Size(97, 17);
            this.infiniteCheckBox.TabIndex = 15;
            this.infiniteCheckBox.Text = "Infinite transmit";
            this.infiniteCheckBox.UseVisualStyleBackColor = true;
            // 
            // withoutPriorCheckBox
            // 
            this.withoutPriorCheckBox.AutoSize = true;
            this.withoutPriorCheckBox.Location = new System.Drawing.Point(197, 79);
            this.withoutPriorCheckBox.Name = "withoutPriorCheckBox";
            this.withoutPriorCheckBox.Size = new System.Drawing.Size(87, 17);
            this.withoutPriorCheckBox.TabIndex = 16;
            this.withoutPriorCheckBox.Text = "Without prior";
            this.withoutPriorCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(305, 391);
            this.Controls.Add(this.withoutPriorCheckBox);
            this.Controls.Add(this.infiniteCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ipTo);
            this.Controls.Add(this.sendMarkerButton);
            this.Controls.Add(this.receiveTextBox);
            this.Controls.Add(this.destTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.wantToSendLabel);
            this.Controls.Add(this.monitorLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.prioComboBox);
            this.Controls.Add(this.monitorCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.port2TextBox);
            this.Controls.Add(this.port1TextBox);
            this.Name = "Form1";
            this.Text = "Token Ring";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox port1TextBox;
        private System.Windows.Forms.TextBox port2TextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox monitorCheckBox;
        private System.Windows.Forms.ComboBox prioComboBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label monitorLabel;
        private System.Windows.Forms.Label wantToSendLabel;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox destTextBox;
        private System.Windows.Forms.TextBox receiveTextBox;
        private System.Windows.Forms.Button sendMarkerButton;
        private System.Windows.Forms.TextBox ipTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox infiniteCheckBox;
        private System.Windows.Forms.CheckBox withoutPriorCheckBox;

    }
}

