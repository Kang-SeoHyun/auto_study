namespace client
{
    partial class client_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client_form));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(37, 172);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(716, 373);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(390, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(363, 38);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(52, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "채팅 할 이름을 입력해주세요 :";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnConnect.Location = new System.Drawing.Point(505, 105);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(248, 48);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "접속하기";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(390, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 1);
            this.panel1.TabIndex = 5;
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMsg.Location = new System.Drawing.Point(37, 570);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(716, 38);
            this.txtMsg.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.Location = new System.Drawing.Point(505, 628);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(248, 48);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "전송하기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // client_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 696);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "client_form";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
    }
}

