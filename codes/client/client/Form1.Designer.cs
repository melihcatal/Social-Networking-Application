namespace client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.alreadyFriendsList = new System.Windows.Forms.CheckedListBox();
            this.button_acceptInvation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button_rejectInvation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.waitingInvations = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.notificationsBox = new System.Windows.Forms.RichTextBox();
            this.newFriendList = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_sendInvitation = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pendingRequestsTextBox = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button_send_private = new System.Windows.Forms.Button();
            this.button_remove_friend = new System.Windows.Forms.Button();
            this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_ip.Location = new System.Drawing.Point(123, 41);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(325, 31);
            this.textBox_ip.TabIndex = 2;
            // 
            // textBox_port
            // 
            this.textBox_port.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_port.Location = new System.Drawing.Point(123, 83);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(325, 31);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_connect.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_connect.ForeColor = System.Drawing.Color.Navy;
            this.button_connect.Location = new System.Drawing.Point(487, 41);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(136, 88);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs
            // 
            this.logs.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logs.Location = new System.Drawing.Point(660, 41);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(640, 296);
            this.logs.TabIndex = 5;
            this.logs.Text = "";
            // 
            // textBox_message
            // 
            this.textBox_message.Enabled = false;
            this.textBox_message.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_message.Location = new System.Drawing.Point(123, 197);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(325, 31);
            this.textBox_message.TabIndex = 6;
            this.textBox_message.TextChanged += new System.EventHandler(this.TextBox_message_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(11, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.Snow;
            this.button_send.Enabled = false;
            this.button_send.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_send.ForeColor = System.Drawing.Color.Red;
            this.button_send.Location = new System.Drawing.Point(123, 242);
            this.button_send.Margin = new System.Windows.Forms.Padding(2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(136, 90);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send All";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(28, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name:";
            // 
            // button_disconnect
            // 
            this.button_disconnect.BackColor = System.Drawing.Color.Red;
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_disconnect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_disconnect.Location = new System.Drawing.Point(487, 133);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(136, 95);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = false;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // alreadyFriendsList
            // 
            this.alreadyFriendsList.CheckOnClick = true;
            this.alreadyFriendsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alreadyFriendsList.FormattingEnabled = true;
            this.alreadyFriendsList.Location = new System.Drawing.Point(960, 413);
            this.alreadyFriendsList.Name = "alreadyFriendsList";
            this.alreadyFriendsList.Size = new System.Drawing.Size(310, 246);
            this.alreadyFriendsList.TabIndex = 13;
            // 
            // button_acceptInvation
            // 
            this.button_acceptInvation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_acceptInvation.Enabled = false;
            this.button_acceptInvation.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_acceptInvation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_acceptInvation.Location = new System.Drawing.Point(572, 675);
            this.button_acceptInvation.Name = "button_acceptInvation";
            this.button_acceptInvation.Size = new System.Drawing.Size(143, 47);
            this.button_acceptInvation.TabIndex = 14;
            this.button_acceptInvation.Text = "Accept";
            this.button_acceptInvation.UseVisualStyleBackColor = false;
            this.button_acceptInvation.Click += new System.EventHandler(this.button_acceptInvation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(589, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Approve Waiting Invitations";
            // 
            // button_rejectInvation
            // 
            this.button_rejectInvation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_rejectInvation.Enabled = false;
            this.button_rejectInvation.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_rejectInvation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_rejectInvation.Location = new System.Drawing.Point(721, 675);
            this.button_rejectInvation.Name = "button_rejectInvation";
            this.button_rejectInvation.Size = new System.Drawing.Size(160, 49);
            this.button_rejectInvation.TabIndex = 16;
            this.button_rejectInvation.Text = "Reject";
            this.button_rejectInvation.UseVisualStyleBackColor = false;
            this.button_rejectInvation.Click += new System.EventHandler(this.Button_rejectInvation_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1020, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Your Friends List";
            // 
            // waitingInvations
            // 
            this.waitingInvations.CheckOnClick = true;
            this.waitingInvations.Enabled = false;
            this.waitingInvations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.waitingInvations.FormattingEnabled = true;
            this.waitingInvations.Location = new System.Drawing.Point(572, 413);
            this.waitingInvations.Name = "waitingInvations";
            this.waitingInvations.Size = new System.Drawing.Size(324, 246);
            this.waitingInvations.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(227, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Notifications";
            // 
            // notificationsBox
            // 
            this.notificationsBox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.notificationsBox.Location = new System.Drawing.Point(33, 403);
            this.notificationsBox.Name = "notificationsBox";
            this.notificationsBox.ReadOnly = true;
            this.notificationsBox.Size = new System.Drawing.Size(518, 319);
            this.notificationsBox.TabIndex = 19;
            this.notificationsBox.Text = "";
            // 
            // newFriendList
            // 
            this.newFriendList.CheckOnClick = true;
            this.newFriendList.Enabled = false;
            this.newFriendList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newFriendList.FormattingEnabled = true;
            this.newFriendList.Location = new System.Drawing.Point(1319, 413);
            this.newFriendList.Name = "newFriendList";
            this.newFriendList.Size = new System.Drawing.Size(329, 246);
            this.newFriendList.TabIndex = 21;
            this.newFriendList.SelectedIndexChanged += new System.EventHandler(this.NewFriendList_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1396, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "Add New Friends";
            // 
            // button_sendInvitation
            // 
            this.button_sendInvitation.BackColor = System.Drawing.Color.LightCoral;
            this.button_sendInvitation.Enabled = false;
            this.button_sendInvitation.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_sendInvitation.ForeColor = System.Drawing.Color.White;
            this.button_sendInvitation.Location = new System.Drawing.Point(1375, 673);
            this.button_sendInvitation.Name = "button_sendInvitation";
            this.button_sendInvitation.Size = new System.Drawing.Size(233, 47);
            this.button_sendInvitation.TabIndex = 23;
            this.button_sendInvitation.Text = "Send Invitation";
            this.button_sendInvitation.UseVisualStyleBackColor = false;
            this.button_sendInvitation.Click += new System.EventHandler(this.button_sendInvitation_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(985, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 28);
            this.label9.TabIndex = 24;
            this.label9.Text = "Logs";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_name.Location = new System.Drawing.Point(123, 137);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(325, 31);
            this.textBox_name.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(1415, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 28);
            this.label10.TabIndex = 27;
            this.label10.Text = "Pending Requests";
            // 
            // pendingRequestsTextBox
            // 
            this.pendingRequestsTextBox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pendingRequestsTextBox.Location = new System.Drawing.Point(1344, 41);
            this.pendingRequestsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pendingRequestsTextBox.Name = "pendingRequestsTextBox";
            this.pendingRequestsTextBox.ReadOnly = true;
            this.pendingRequestsTextBox.Size = new System.Drawing.Size(304, 291);
            this.pendingRequestsTextBox.TabIndex = 28;
            this.pendingRequestsTextBox.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "New Notification!";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button_send_private
            // 
            this.button_send_private.BackColor = System.Drawing.Color.Snow;
            this.button_send_private.Enabled = false;
            this.button_send_private.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_send_private.ForeColor = System.Drawing.Color.Red;
            this.button_send_private.Location = new System.Drawing.Point(291, 242);
            this.button_send_private.Margin = new System.Windows.Forms.Padding(2);
            this.button_send_private.Name = "button_send_private";
            this.button_send_private.Size = new System.Drawing.Size(157, 90);
            this.button_send_private.TabIndex = 29;
            this.button_send_private.Text = "Send Private Message";
            this.button_send_private.UseVisualStyleBackColor = false;
            this.button_send_private.Click += new System.EventHandler(this.Button_send_private_Click);
            // 
            // button_remove_friend
            // 
            this.button_remove_friend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_remove_friend.Enabled = false;
            this.button_remove_friend.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_remove_friend.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_remove_friend.Location = new System.Drawing.Point(1024, 673);
            this.button_remove_friend.Name = "button_remove_friend";
            this.button_remove_friend.Size = new System.Drawing.Size(160, 49);
            this.button_remove_friend.TabIndex = 30;
            this.button_remove_friend.Text = "Remove";
            this.button_remove_friend.UseVisualStyleBackColor = false;
            this.button_remove_friend.Click += new System.EventHandler(this.Button_remove_friend_Click);
            // 
            // form1BindingSource1
            // 
            this.form1BindingSource1.DataSource = typeof(client.Form1);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(client.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1681, 746);
            this.Controls.Add(this.button_remove_friend);
            this.Controls.Add(this.button_send_private);
            this.Controls.Add(this.pendingRequestsTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_sendInvitation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.newFriendList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.notificationsBox);
            this.Controls.Add(this.waitingInvations);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_rejectInvation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_acceptInvation);
            this.Controls.Add(this.alreadyFriendsList);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.CheckedListBox alreadyFriendsList;
        private System.Windows.Forms.Button button_acceptInvation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_rejectInvation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox waitingInvations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox notificationsBox;
        private System.Windows.Forms.CheckedListBox newFriendList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_sendInvitation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource form1BindingSource1;
        private System.Windows.Forms.RichTextBox pendingRequestsTextBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button_send_private;
        private System.Windows.Forms.Button button_remove_friend;
    }
}

