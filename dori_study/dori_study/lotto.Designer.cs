namespace dori_study
{
    partial class lotto
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
            this.lblResult = new System.Windows.Forms.Label();
            this.tboxResult = new System.Windows.Forms.Label();
            this.btnResult = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tboxNumber = new System.Windows.Forms.TextBox();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblResult.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.ForeColor = System.Drawing.Color.Black;
            this.lblResult.Location = new System.Drawing.Point(47, 58);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(333, 47);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "0. 0. 0. 0. 0. 0";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxResult
            // 
            this.tboxResult.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tboxResult.Location = new System.Drawing.Point(34, 449);
            this.tboxResult.Name = "tboxResult";
            this.tboxResult.Size = new System.Drawing.Size(288, 26);
            this.tboxResult.TabIndex = 1;
            this.tboxResult.Text = "1~100안의 숫자를 선택 하세요.";
            this.tboxResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResult.Image = global::dori_study.Properties.Resources.분홍_하늘;
            this.btnResult.Location = new System.Drawing.Point(409, 58);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(124, 47);
            this.btnResult.TabIndex = 2;
            this.btnResult.Text = "로또 번호";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(47, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(333, 289);
            this.listBox1.TabIndex = 3;
            // 
            // tboxNumber
            // 
            this.tboxNumber.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tboxNumber.Location = new System.Drawing.Point(47, 484);
            this.tboxNumber.Name = "tboxNumber";
            this.tboxNumber.Size = new System.Drawing.Size(79, 28);
            this.tboxNumber.TabIndex = 4;
            this.tboxNumber.Text = "1";
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult2.Location = new System.Drawing.Point(48, 543);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(17, 18);
            this.lblResult2.TabIndex = 5;
            this.lblResult2.Text = "-";
            this.lblResult2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Image = global::dori_study.Properties.Resources.분홍_하늘;
            this.button1.Location = new System.Drawing.Point(174, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "선택 번호 뽑기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.Location = new System.Drawing.Point(47, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 10);
            this.panel1.TabIndex = 7;
            // 
            // lotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(557, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.tboxNumber);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.tboxResult);
            this.Controls.Add(this.lblResult);
            this.Name = "lotto";
            this.Text = "lotto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label tboxResult;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tboxNumber;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}