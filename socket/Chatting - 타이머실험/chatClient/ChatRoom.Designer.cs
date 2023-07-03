namespace chatClient
{
    partial class ChatRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatRoom));
            this.rTxtMsg = new System.Windows.Forms.RichTextBox();
            this.listJoin = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnImgSend = new System.Windows.Forms.Button();
            this.btnGoOut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblLeave = new System.Windows.Forms.Label();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer_list = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.listLogin = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // rTxtMsg
            // 
            this.rTxtMsg.BackColor = System.Drawing.Color.Azure;
            this.rTxtMsg.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rTxtMsg.Location = new System.Drawing.Point(40, 120);
            this.rTxtMsg.Name = "rTxtMsg";
            this.rTxtMsg.ReadOnly = true;
            this.rTxtMsg.Size = new System.Drawing.Size(428, 573);
            this.rTxtMsg.TabIndex = 4;
            this.rTxtMsg.Text = "";
            // 
            // listJoin
            // 
            this.listJoin.BackColor = System.Drawing.Color.Azure;
            this.listJoin.FormattingEnabled = true;
            this.listJoin.ItemHeight = 15;
            this.listJoin.Location = new System.Drawing.Point(510, 404);
            this.listJoin.Name = "listJoin";
            this.listJoin.Size = new System.Drawing.Size(153, 289);
            this.listJoin.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(506, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "방 참여자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(506, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "이미지";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(36, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "메세지";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Azure;
            this.pictureBox1.Location = new System.Drawing.Point(510, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 190);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMsg.Location = new System.Drawing.Point(40, 725);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(801, 62);
            this.txtMsg.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.BackgroundImage = global::chatClient.Properties.Resources.파스텔;
            this.btnSend.Location = new System.Drawing.Point(527, 812);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(169, 62);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnImgSend
            // 
            this.btnImgSend.BackgroundImage = global::chatClient.Properties.Resources.파스텔;
            this.btnImgSend.Location = new System.Drawing.Point(729, 317);
            this.btnImgSend.Name = "btnImgSend";
            this.btnImgSend.Size = new System.Drawing.Size(112, 49);
            this.btnImgSend.TabIndex = 3;
            this.btnImgSend.Text = "이미지전송";
            this.btnImgSend.UseVisualStyleBackColor = true;
            // 
            // btnGoOut
            // 
            this.btnGoOut.BackgroundImage = global::chatClient.Properties.Resources.파스텔;
            this.btnGoOut.Location = new System.Drawing.Point(216, 812);
            this.btnGoOut.Name = "btnGoOut";
            this.btnGoOut.Size = new System.Drawing.Size(169, 62);
            this.btnGoOut.TabIndex = 2;
            this.btnGoOut.Text = "다른방가기";
            this.btnGoOut.UseVisualStyleBackColor = true;
            this.btnGoOut.Click += new System.EventHandler(this.btnGoOut_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::chatClient.Properties.Resources.파스텔;
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.lblLeave);
            this.panel1.Controls.Add(this.picLogout);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 64);
            this.panel1.TabIndex = 11;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("돋움체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWelcome.Location = new System.Drawing.Point(246, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(98, 18);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "웰컴텍스트";
            // 
            // lblLeave
            // 
            this.lblLeave.AutoSize = true;
            this.lblLeave.BackColor = System.Drawing.Color.Transparent;
            this.lblLeave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLeave.Location = new System.Drawing.Point(801, 43);
            this.lblLeave.Name = "lblLeave";
            this.lblLeave.Size = new System.Drawing.Size(54, 20);
            this.lblLeave.TabIndex = 3;
            this.lblLeave.Text = "나가기";
            this.lblLeave.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // picLogout
            // 
            this.picLogout.BackColor = System.Drawing.Color.Transparent;
            this.picLogout.BackgroundImage = global::chatClient.Properties.Resources.free_icon_enter_1828395;
            this.picLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogout.Location = new System.Drawing.Point(799, 3);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(56, 40);
            this.picLogout.TabIndex = 3;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::chatClient.Properties.Resources.free_icon_bubble_chat_3820168;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 58);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTime.Location = new System.Drawing.Point(350, 14);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 41);
            this.lbTime.TabIndex = 0;
            // 
            // timer_list
            // 
            this.timer_list.Interval = 300;
            this.timer_list.Tick += new System.EventHandler(this.timer_list_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(684, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "접속자";
            // 
            // listLogin
            // 
            this.listLogin.BackColor = System.Drawing.Color.Azure;
            this.listLogin.FormattingEnabled = true;
            this.listLogin.ItemHeight = 15;
            this.listLogin.Location = new System.Drawing.Point(688, 404);
            this.listLogin.Name = "listLogin";
            this.listLogin.Size = new System.Drawing.Size(153, 289);
            this.listLogin.TabIndex = 13;
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(861, 903);
            this.Controls.Add(this.listLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGoOut);
            this.Controls.Add(this.btnImgSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listJoin);
            this.Controls.Add(this.rTxtMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtMsg;
        private System.Windows.Forms.ListBox listJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnImgSend;
        private System.Windows.Forms.Button btnGoOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeave;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Timer timer_list;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listLogin;
    }
}