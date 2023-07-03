namespace chatClient
{
    partial class ChatRoomList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatRoomList));
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAdd = new System.Windows.Forms.Label();
            this.cboxTeam = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picChatJoin = new System.Windows.Forms.PictureBox();
            this.picMyRoom = new System.Windows.Forms.PictureBox();
            this.picAllRoom = new System.Windows.Forms.PictureBox();
            this.picChatAdd = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbLogout = new System.Windows.Forms.Label();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChatJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMyRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAllRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChatAdd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTime
            // 
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(33, 164);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(799, 603);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "방 이름";
            this.columnHeader1.Width = 185;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "마지막 대화";
            this.columnHeader2.Width = 273;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "참여자";
            this.columnHeader3.Width = 222;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAdd.Location = new System.Drawing.Point(839, 626);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(89, 20);
            this.lblAdd.TabIndex = 38;
            this.lblAdd.Text = "채팅방 추가";
            // 
            // cboxTeam
            // 
            this.cboxTeam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboxTeam.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cboxTeam.FormattingEnabled = true;
            this.cboxTeam.Items.AddRange(new object[] {
            "1팀",
            "2팀",
            "3팀",
            "4팀"});
            this.cboxTeam.Location = new System.Drawing.Point(731, 96);
            this.cboxTeam.Name = "cboxTeam";
            this.cboxTeam.Size = new System.Drawing.Size(214, 36);
            this.cboxTeam.TabIndex = 43;
            this.cboxTeam.Text = "소속을 선택해주세요.";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(537, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 1);
            this.panel3.TabIndex = 41;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtName.Location = new System.Drawing.Point(537, 96);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 35);
            this.txtName.TabIndex = 39;
            this.txtName.Text = "이름을 입력하세요.";
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(839, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "내 방 보기";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblName.Location = new System.Drawing.Point(12, 86);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 31);
            this.lblName.TabIndex = 46;
            this.lblName.Text = "웰컴텍스트";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(838, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "전체 방 보기";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(839, 747);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "채팅방 접속";
            // 
            // picUpdate
            // 
            this.picUpdate.BackgroundImage = global::chatClient.Properties.Resources.free_icon_reload_6066779;
            this.picUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUpdate.ErrorImage = null;
            this.picUpdate.Location = new System.Drawing.Point(769, 160);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(45, 32);
            this.picUpdate.TabIndex = 53;
            this.picUpdate.TabStop = false;
            this.picUpdate.Click += new System.EventHandler(this.picUpdate_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::chatClient.Properties.Resources.free_icon_magnifying_glass_3603748;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(477, 86);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(54, 46);
            this.pictureBox4.TabIndex = 47;
            this.pictureBox4.TabStop = false;
            // 
            // picChatJoin
            // 
            this.picChatJoin.BackColor = System.Drawing.Color.Transparent;
            this.picChatJoin.BackgroundImage = global::chatClient.Properties.Resources.free_icon_chat_group_4339395;
            this.picChatJoin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picChatJoin.Location = new System.Drawing.Point(843, 664);
            this.picChatJoin.Name = "picChatJoin";
            this.picChatJoin.Size = new System.Drawing.Size(85, 80);
            this.picChatJoin.TabIndex = 52;
            this.picChatJoin.TabStop = false;
            this.picChatJoin.Click += new System.EventHandler(this.picChatJoin_Click);
            // 
            // picMyRoom
            // 
            this.picMyRoom.BackColor = System.Drawing.Color.Transparent;
            this.picMyRoom.BackgroundImage = global::chatClient.Properties.Resources.free_icon_chat_5465394;
            this.picMyRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMyRoom.Location = new System.Drawing.Point(843, 417);
            this.picMyRoom.Name = "picMyRoom";
            this.picMyRoom.Size = new System.Drawing.Size(78, 80);
            this.picMyRoom.TabIndex = 50;
            this.picMyRoom.TabStop = false;
            this.picMyRoom.Click += new System.EventHandler(this.picMyRoom_Click);
            // 
            // picAllRoom
            // 
            this.picAllRoom.BackColor = System.Drawing.Color.Transparent;
            this.picAllRoom.BackgroundImage = global::chatClient.Properties.Resources.free_icon_bubble_chat_3820168;
            this.picAllRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picAllRoom.Location = new System.Drawing.Point(843, 286);
            this.picAllRoom.Name = "picAllRoom";
            this.picAllRoom.Size = new System.Drawing.Size(85, 80);
            this.picAllRoom.TabIndex = 48;
            this.picAllRoom.TabStop = false;
            this.picAllRoom.Click += new System.EventHandler(this.picAllRoom_Click);
            // 
            // picChatAdd
            // 
            this.picChatAdd.BackColor = System.Drawing.Color.Transparent;
            this.picChatAdd.BackgroundImage = global::chatClient.Properties.Resources.free_icon_add_5150518;
            this.picChatAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picChatAdd.Location = new System.Drawing.Point(843, 543);
            this.picChatAdd.Name = "picChatAdd";
            this.picChatAdd.Size = new System.Drawing.Size(78, 80);
            this.picChatAdd.TabIndex = 44;
            this.picChatAdd.TabStop = false;
            this.picChatAdd.Click += new System.EventHandler(this.picChatAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::chatClient.Properties.Resources.파스텔;
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lbLogout);
            this.panel1.Controls.Add(this.picLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 76);
            this.panel1.TabIndex = 2;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTime.Location = new System.Drawing.Point(89, 19);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 41);
            this.lbTime.TabIndex = 0;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Transparent;
            this.lblMode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMode.Location = new System.Drawing.Point(380, 14);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(179, 41);
            this.lblMode.TabIndex = 45;
            this.lblMode.Text = "전체 채팅방";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::chatClient.Properties.Resources.free_icon_clock_2997985;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(12, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 68);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // lbLogout
            // 
            this.lbLogout.AutoSize = true;
            this.lbLogout.BackColor = System.Drawing.Color.Transparent;
            this.lbLogout.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbLogout.Location = new System.Drawing.Point(896, 51);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(69, 20);
            this.lbLogout.TabIndex = 3;
            this.lbLogout.Text = "로그아웃";
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // picLogout
            // 
            this.picLogout.BackColor = System.Drawing.Color.Transparent;
            this.picLogout.BackgroundImage = global::chatClient.Properties.Resources.free_icon_arrow_10901899;
            this.picLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogout.Location = new System.Drawing.Point(900, 3);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(64, 55);
            this.picLogout.TabIndex = 3;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(737, 171);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 15);
            this.lblUpdate.TabIndex = 54;
            // 
            // ChatRoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(967, 786);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.picUpdate);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.picChatJoin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picMyRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picAllRoom);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picChatAdd);
            this.Controls.Add(this.cboxTeam);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatRoomList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatList";
            this.Load += new System.EventHandler(this.ChatRoomList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChatJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMyRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAllRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChatAdd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Label lbLogout;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.ComboBox cboxTeam;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox picChatAdd;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAllRoom;
        private System.Windows.Forms.PictureBox picMyRoom;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox picChatJoin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label lblUpdate;
    }
}