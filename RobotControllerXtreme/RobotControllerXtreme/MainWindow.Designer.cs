namespace RobotControllerXtreme
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ForwardButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButon = new System.Windows.Forms.Button();
            this.CommandsGroupBox = new System.Windows.Forms.GroupBox();
            this.SerialConnectButton = new System.Windows.Forms.Button();
            this.SerialCommunicationBox = new System.Windows.Forms.ListBox();
            this.PublishButton = new System.Windows.Forms.Button();
            this.ConnectionStatusBox = new System.Windows.Forms.ListBox();
            this.PayloadTextBox = new System.Windows.Forms.TextBox();
            this.MQTTGroupBox = new System.Windows.Forms.GroupBox();
            this.CommandsGroupBox.SuspendLayout();
            this.MQTTGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForwardButton
            // 
            this.ForwardButton.Enabled = false;
            this.ForwardButton.Location = new System.Drawing.Point(128, 19);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(108, 65);
            this.ForwardButton.TabIndex = 0;
            this.ForwardButton.Text = "Forward";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Location = new System.Drawing.Point(128, 158);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(108, 66);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(128, 90);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(108, 62);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Enabled = false;
            this.LeftButton.Location = new System.Drawing.Point(6, 90);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(116, 62);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Enabled = false;
            this.RightButton.Location = new System.Drawing.Point(242, 90);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(118, 62);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(30, 59);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButon
            // 
            this.DisconnectButon.Enabled = false;
            this.DisconnectButon.Location = new System.Drawing.Point(242, 59);
            this.DisconnectButon.Name = "DisconnectButon";
            this.DisconnectButon.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButon.TabIndex = 7;
            this.DisconnectButon.Text = "Disconnect";
            this.DisconnectButon.UseVisualStyleBackColor = true;
            this.DisconnectButon.Click += new System.EventHandler(this.DisconnectButon_Click);
            // 
            // CommandsGroupBox
            // 
            this.CommandsGroupBox.Controls.Add(this.SerialConnectButton);
            this.CommandsGroupBox.Controls.Add(this.SerialCommunicationBox);
            this.CommandsGroupBox.Controls.Add(this.RightButton);
            this.CommandsGroupBox.Controls.Add(this.LeftButton);
            this.CommandsGroupBox.Controls.Add(this.StopButton);
            this.CommandsGroupBox.Controls.Add(this.BackButton);
            this.CommandsGroupBox.Controls.Add(this.ForwardButton);
            this.CommandsGroupBox.Location = new System.Drawing.Point(379, 21);
            this.CommandsGroupBox.Name = "CommandsGroupBox";
            this.CommandsGroupBox.Size = new System.Drawing.Size(370, 376);
            this.CommandsGroupBox.TabIndex = 8;
            this.CommandsGroupBox.TabStop = false;
            this.CommandsGroupBox.Text = "Commands";
            // 
            // SerialConnectButton
            // 
            this.SerialConnectButton.Location = new System.Drawing.Point(6, 19);
            this.SerialConnectButton.Name = "SerialConnectButton";
            this.SerialConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SerialConnectButton.TabIndex = 7;
            this.SerialConnectButton.Text = "Connect";
            this.SerialConnectButton.UseVisualStyleBackColor = true;
            this.SerialConnectButton.Click += new System.EventHandler(this.SerialConnectButton_Click);
            // 
            // SerialCommunicationBox
            // 
            this.SerialCommunicationBox.Enabled = false;
            this.SerialCommunicationBox.FormattingEnabled = true;
            this.SerialCommunicationBox.Location = new System.Drawing.Point(6, 230);
            this.SerialCommunicationBox.Name = "SerialCommunicationBox";
            this.SerialCommunicationBox.Size = new System.Drawing.Size(358, 134);
            this.SerialCommunicationBox.TabIndex = 6;
            // 
            // PublishButton
            // 
            this.PublishButton.Enabled = false;
            this.PublishButton.Location = new System.Drawing.Point(135, 59);
            this.PublishButton.Name = "PublishButton";
            this.PublishButton.Size = new System.Drawing.Size(75, 23);
            this.PublishButton.TabIndex = 9;
            this.PublishButton.Text = "Publish";
            this.PublishButton.UseVisualStyleBackColor = true;
            this.PublishButton.Click += new System.EventHandler(this.PublishButton_Click);
            // 
            // ConnectionStatusBox
            // 
            this.ConnectionStatusBox.FormattingEnabled = true;
            this.ConnectionStatusBox.Location = new System.Drawing.Point(7, 230);
            this.ConnectionStatusBox.Name = "ConnectionStatusBox";
            this.ConnectionStatusBox.Size = new System.Drawing.Size(348, 134);
            this.ConnectionStatusBox.TabIndex = 10;
            // 
            // PayloadTextBox
            // 
            this.PayloadTextBox.Location = new System.Drawing.Point(30, 19);
            this.PayloadTextBox.Name = "PayloadTextBox";
            this.PayloadTextBox.Size = new System.Drawing.Size(287, 20);
            this.PayloadTextBox.TabIndex = 11;
            // 
            // MQTTGroupBox
            // 
            this.MQTTGroupBox.Controls.Add(this.PayloadTextBox);
            this.MQTTGroupBox.Controls.Add(this.ConnectionStatusBox);
            this.MQTTGroupBox.Controls.Add(this.ConnectButton);
            this.MQTTGroupBox.Controls.Add(this.PublishButton);
            this.MQTTGroupBox.Controls.Add(this.DisconnectButon);
            this.MQTTGroupBox.Location = new System.Drawing.Point(12, 21);
            this.MQTTGroupBox.Name = "MQTTGroupBox";
            this.MQTTGroupBox.Size = new System.Drawing.Size(361, 376);
            this.MQTTGroupBox.TabIndex = 12;
            this.MQTTGroupBox.TabStop = false;
            this.MQTTGroupBox.Text = "MQTT";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 404);
            this.Controls.Add(this.MQTTGroupBox);
            this.Controls.Add(this.CommandsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "RobotControllerXtreme";
            this.CommandsGroupBox.ResumeLayout(false);
            this.MQTTGroupBox.ResumeLayout(false);
            this.MQTTGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButon;
        private System.Windows.Forms.GroupBox CommandsGroupBox;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.ListBox ConnectionStatusBox;
        private System.Windows.Forms.TextBox PayloadTextBox;
        private System.Windows.Forms.ListBox SerialCommunicationBox;
        private System.Windows.Forms.GroupBox MQTTGroupBox;
        private System.Windows.Forms.Button SerialConnectButton;
    }
}

