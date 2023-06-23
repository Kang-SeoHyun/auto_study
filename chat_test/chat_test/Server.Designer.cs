namespace chat_test
{
    partial class Server
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_server_send = new System.Windows.Forms.Button();
            this.txt_server_chat = new System.Windows.Forms.TextBox();
            this.txt_server_send = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_server_send
            // 
            this.button_server_send.Location = new System.Drawing.Point(596, 581);
            this.button_server_send.Name = "button_server_send";
            this.button_server_send.Size = new System.Drawing.Size(143, 62);
            this.button_server_send.TabIndex = 2;
            this.button_server_send.Text = "보내기";
            this.button_server_send.UseVisualStyleBackColor = true;
            this.button_server_send.Click += new System.EventHandler(this.button_server_send_Click);
            // 
            // txt_server_chat
            // 
            this.txt_server_chat.Font = new System.Drawing.Font("굴림", 10F);
            this.txt_server_chat.Location = new System.Drawing.Point(20, 20);
            this.txt_server_chat.Multiline = true;
            this.txt_server_chat.Name = "txt_server_chat";
            this.txt_server_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_server_chat.Size = new System.Drawing.Size(719, 537);
            this.txt_server_chat.TabIndex = 3;
            // 
            // txt_server_send
            // 
            this.txt_server_send.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_server_send.Location = new System.Drawing.Point(20, 598);
            this.txt_server_send.Name = "txt_server_send";
            this.txt_server_send.Size = new System.Drawing.Size(553, 30);
            this.txt_server_send.TabIndex = 1;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 670);
            this.Controls.Add(this.txt_server_send);
            this.Controls.Add(this.txt_server_chat);
            this.Controls.Add(this.button_server_send);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_server_send;
        private System.Windows.Forms.TextBox txt_server_chat;
        private System.Windows.Forms.TextBox txt_server_send;
    }
}

