namespace chat_test_cli
{
    partial class Client
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
            this.txt_client_send = new System.Windows.Forms.TextBox();
            this.txt_client_chat = new System.Windows.Forms.TextBox();
            this.button_client_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_client_send
            // 
            this.txt_client_send.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_client_send.Location = new System.Drawing.Point(25, 602);
            this.txt_client_send.Name = "txt_client_send";
            this.txt_client_send.Size = new System.Drawing.Size(553, 30);
            this.txt_client_send.TabIndex = 4;
            // 
            // txt_client_chat
            // 
            this.txt_client_chat.Font = new System.Drawing.Font("굴림", 10F);
            this.txt_client_chat.Location = new System.Drawing.Point(25, 24);
            this.txt_client_chat.Multiline = true;
            this.txt_client_chat.Name = "txt_client_chat";
            this.txt_client_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_client_chat.Size = new System.Drawing.Size(719, 537);
            this.txt_client_chat.TabIndex = 6;
            // 
            // button_client_send
            // 
            this.button_client_send.Location = new System.Drawing.Point(601, 585);
            this.button_client_send.Name = "button_client_send";
            this.button_client_send.Size = new System.Drawing.Size(143, 62);
            this.button_client_send.TabIndex = 5;
            this.button_client_send.Text = "보내기";
            this.button_client_send.UseVisualStyleBackColor = true;
            this.button_client_send.Click += new System.EventHandler(this.button_client_send_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 670);
            this.Controls.Add(this.txt_client_send);
            this.Controls.Add(this.txt_client_chat);
            this.Controls.Add(this.button_client_send);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_client_send;
        private System.Windows.Forms.TextBox txt_client_chat;
        private System.Windows.Forms.Button button_client_send;
    }
}