namespace dori_study
{
    partial class list_Box
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
            this.name = new System.Windows.Forms.TextBox();
            this.result1 = new System.Windows.Forms.Button();
            this.result2 = new System.Windows.Forms.Button();
            this.Day = new System.Windows.Forms.ListBox();
            this.Time = new System.Windows.Forms.ListBox();
            this.tBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(51, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(119, 25);
            this.name.TabIndex = 0;
            // 
            // result1
            // 
            this.result1.Location = new System.Drawing.Point(51, 318);
            this.result1.Name = "result1";
            this.result1.Size = new System.Drawing.Size(86, 45);
            this.result1.TabIndex = 1;
            this.result1.Text = "결과보기";
            this.result1.UseVisualStyleBackColor = true;
            this.result1.Click += new System.EventHandler(this.result1_Click);
            // 
            // result2
            // 
            this.result2.Location = new System.Drawing.Point(163, 318);
            this.result2.Name = "result2";
            this.result2.Size = new System.Drawing.Size(137, 45);
            this.result2.TabIndex = 2;
            this.result2.Text = "StringFormat Test";
            this.result2.UseVisualStyleBackColor = true;
            this.result2.Click += new System.EventHandler(this.result2_Click);
            // 
            // Day
            // 
            this.Day.FormattingEnabled = true;
            this.Day.ItemHeight = 15;
            this.Day.Location = new System.Drawing.Point(51, 81);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(198, 214);
            this.Day.TabIndex = 3;
            // 
            // Time
            // 
            this.Time.FormattingEnabled = true;
            this.Time.ItemHeight = 15;
            this.Time.Location = new System.Drawing.Point(267, 81);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(206, 214);
            this.Time.TabIndex = 4;
            // 
            // tBoxResult
            // 
            this.tBoxResult.Enabled = false;
            this.tBoxResult.Location = new System.Drawing.Point(51, 401);
            this.tBoxResult.Multiline = true;
            this.tBoxResult.Name = "tBoxResult";
            this.tBoxResult.Size = new System.Drawing.Size(422, 79);
            this.tBoxResult.TabIndex = 5;
            this.tBoxResult.TextChanged += new System.EventHandler(this.tBoxResult_TextChanged);
            // 
            // list_Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 526);
            this.Controls.Add(this.tBoxResult);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.result2);
            this.Controls.Add(this.result1);
            this.Controls.Add(this.name);
            this.Name = "list_Box";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button result1;
        private System.Windows.Forms.Button result2;
        private System.Windows.Forms.ListBox Day;
        private System.Windows.Forms.ListBox Time;
        private System.Windows.Forms.TextBox tBoxResult;
    }
}

