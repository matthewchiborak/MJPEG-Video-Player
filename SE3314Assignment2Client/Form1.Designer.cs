namespace SE3314Assignment2Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.portNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ipaddressBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.videoSelect = new System.Windows.Forms.ComboBox();
            this.videoBox = new System.Windows.Forms.PictureBox();
            this.setupButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.teardownButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.ListBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.requestBox = new System.Windows.Forms.ListBox();
            this.packetReportCheckbox = new System.Windows.Forms.CheckBox();
            this.printHeaderCheckbox = new System.Windows.Forms.CheckBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect to Port:";
            // 
            // portNumberBox
            // 
            this.portNumberBox.Location = new System.Drawing.Point(103, 11);
            this.portNumberBox.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.portNumberBox.Name = "portNumberBox";
            this.portNumberBox.Size = new System.Drawing.Size(82, 20);
            this.portNumberBox.TabIndex = 1;
            this.portNumberBox.ValueChanged += new System.EventHandler(this.portNumberBox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server IP address: ";
            // 
            // ipaddressBox
            // 
            this.ipaddressBox.Location = new System.Drawing.Point(295, 10);
            this.ipaddressBox.Name = "ipaddressBox";
            this.ipaddressBox.Size = new System.Drawing.Size(100, 20);
            this.ipaddressBox.TabIndex = 3;
            this.ipaddressBox.Text = "127.0.0.1";
            this.ipaddressBox.TextChanged += new System.EventHandler(this.ipaddressBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Video name: ";
            // 
            // videoSelect
            // 
            this.videoSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoSelect.FormattingEnabled = true;
            this.videoSelect.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.videoSelect.Location = new System.Drawing.Point(478, 9);
            this.videoSelect.Name = "videoSelect";
            this.videoSelect.Size = new System.Drawing.Size(121, 21);
            this.videoSelect.TabIndex = 5;
            this.videoSelect.SelectedIndexChanged += new System.EventHandler(this.videoSelect_SelectedIndexChanged);
            // 
            // videoBox
            // 
            this.videoBox.Location = new System.Drawing.Point(85, 37);
            this.videoBox.Name = "videoBox";
            this.videoBox.Size = new System.Drawing.Size(448, 243);
            this.videoBox.TabIndex = 6;
            this.videoBox.TabStop = false;
            this.videoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseClick);
            this.videoBox.MouseEnter += new System.EventHandler(this.videoBox_MouseEnter);
            this.videoBox.MouseLeave += new System.EventHandler(this.videoBox_MouseLeave);
            this.videoBox.MouseHover += new System.EventHandler(this.videoBox_MouseHover);
            this.videoBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseUp);
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(30, 300);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(98, 79);
            this.setupButton.TabIndex = 7;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(173, 300);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(115, 76);
            this.playButton.TabIndex = 8;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(335, 300);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(115, 79);
            this.pauseButton.TabIndex = 9;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // teardownButton
            // 
            this.teardownButton.Location = new System.Drawing.Point(492, 300);
            this.teardownButton.Name = "teardownButton";
            this.teardownButton.Size = new System.Drawing.Size(107, 79);
            this.teardownButton.TabIndex = 10;
            this.teardownButton.Text = "Teardown";
            this.teardownButton.UseVisualStyleBackColor = true;
            this.teardownButton.Click += new System.EventHandler(this.teardownButton_Click);
            // 
            // statusBox
            // 
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Location = new System.Drawing.Point(30, 385);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(468, 147);
            this.statusBox.TabIndex = 11;
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(30, 539);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(94, 13);
            this.responseLabel.TabIndex = 12;
            this.responseLabel.Text = "Server Responses";
            // 
            // requestBox
            // 
            this.requestBox.FormattingEnabled = true;
            this.requestBox.Location = new System.Drawing.Point(30, 556);
            this.requestBox.Name = "requestBox";
            this.requestBox.Size = new System.Drawing.Size(468, 147);
            this.requestBox.TabIndex = 13;
            // 
            // packetReportCheckbox
            // 
            this.packetReportCheckbox.AutoSize = true;
            this.packetReportCheckbox.Location = new System.Drawing.Point(513, 432);
            this.packetReportCheckbox.Name = "packetReportCheckbox";
            this.packetReportCheckbox.Size = new System.Drawing.Size(95, 17);
            this.packetReportCheckbox.TabIndex = 14;
            this.packetReportCheckbox.Text = "Packet Report";
            this.packetReportCheckbox.UseVisualStyleBackColor = true;
            // 
            // printHeaderCheckbox
            // 
            this.printHeaderCheckbox.AutoSize = true;
            this.printHeaderCheckbox.Location = new System.Drawing.Point(513, 467);
            this.printHeaderCheckbox.Name = "printHeaderCheckbox";
            this.printHeaderCheckbox.Size = new System.Drawing.Size(85, 17);
            this.printHeaderCheckbox.TabIndex = 15;
            this.printHeaderCheckbox.Text = "Print Header";
            this.printHeaderCheckbox.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(524, 611);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 16;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(523, 653);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 716);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.printHeaderCheckbox);
            this.Controls.Add(this.packetReportCheckbox);
            this.Controls.Add(this.requestBox);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.teardownButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.videoSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ipaddressBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portNumberBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.portNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown portNumberBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipaddressBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox videoSelect;
        private System.Windows.Forms.PictureBox videoBox;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button teardownButton;
        private System.Windows.Forms.ListBox statusBox;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.ListBox requestBox;
        private System.Windows.Forms.CheckBox packetReportCheckbox;
        private System.Windows.Forms.CheckBox printHeaderCheckbox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button exitButton;
    }
}

