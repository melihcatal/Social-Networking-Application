namespace server
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.onlineClientsLogs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.offlineClientsLogs = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.totalOnlineClientCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalOffilneClientsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_port.Location = new System.Drawing.Point(350, 31);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(282, 35);
            this.textBox_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(196, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_listen.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_listen.Location = new System.Drawing.Point(714, 22);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(135, 53);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = false;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // logs
            // 
            this.logs.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logs.ForeColor = System.Drawing.Color.DarkRed;
            this.logs.Location = new System.Drawing.Point(16, 131);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(953, 674);
            this.logs.TabIndex = 3;
            this.logs.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(1166, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Online Clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1625, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offline Clients";
            // 
            // onlineClientsLogs
            // 
            this.onlineClientsLogs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onlineClientsLogs.Location = new System.Drawing.Point(1019, 92);
            this.onlineClientsLogs.Name = "onlineClientsLogs";
            this.onlineClientsLogs.ReadOnly = true;
            this.onlineClientsLogs.Size = new System.Drawing.Size(411, 651);
            this.onlineClientsLogs.TabIndex = 6;
            this.onlineClientsLogs.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(439, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "Logs";
            // 
            // offlineClientsLogs
            // 
            this.offlineClientsLogs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.offlineClientsLogs.Location = new System.Drawing.Point(1519, 89);
            this.offlineClientsLogs.Name = "offlineClientsLogs";
            this.offlineClientsLogs.ReadOnly = true;
            this.offlineClientsLogs.Size = new System.Drawing.Size(381, 651);
            this.offlineClientsLogs.TabIndex = 8;
            this.offlineClientsLogs.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1075, 777);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Online Clients: ";
            // 
            // totalOnlineClientCount
            // 
            this.totalOnlineClientCount.AutoSize = true;
            this.totalOnlineClientCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalOnlineClientCount.ForeColor = System.Drawing.Color.Red;
            this.totalOnlineClientCount.Location = new System.Drawing.Point(1320, 775);
            this.totalOnlineClientCount.Name = "totalOnlineClientCount";
            this.totalOnlineClientCount.Size = new System.Drawing.Size(21, 23);
            this.totalOnlineClientCount.TabIndex = 10;
            this.totalOnlineClientCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1572, 778);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Offline Clients: ";
            // 
            // totalOffilneClientsCount
            // 
            this.totalOffilneClientsCount.AutoSize = true;
            this.totalOffilneClientsCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalOffilneClientsCount.ForeColor = System.Drawing.Color.Red;
            this.totalOffilneClientsCount.Location = new System.Drawing.Point(1823, 774);
            this.totalOffilneClientsCount.Name = "totalOffilneClientsCount";
            this.totalOffilneClientsCount.Size = new System.Drawing.Size(21, 23);
            this.totalOffilneClientsCount.TabIndex = 12;
            this.totalOffilneClientsCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2003, 834);
            this.Controls.Add(this.totalOffilneClientsCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalOnlineClientCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.offlineClientsLogs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.onlineClientsLogs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox onlineClientsLogs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox offlineClientsLogs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalOnlineClientCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalOffilneClientsCount;
    }
}

