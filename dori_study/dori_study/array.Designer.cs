namespace dori_study
{
    partial class array
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblArrayCnt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "매장 방문 수";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDay1,
            this.colDay2,
            this.colDay3,
            this.colDay4,
            this.colDay5,
            this.colDay6,
            this.colDay7});
            this.dataGridView1.Location = new System.Drawing.Point(36, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(963, 129);
            this.dataGridView1.TabIndex = 1;
            // 
            // colDay1
            // 
            this.colDay1.HeaderText = "월";
            this.colDay1.MinimumWidth = 6;
            this.colDay1.Name = "colDay1";
            this.colDay1.Width = 125;
            // 
            // colDay2
            // 
            this.colDay2.HeaderText = "화";
            this.colDay2.MinimumWidth = 6;
            this.colDay2.Name = "colDay2";
            this.colDay2.Width = 125;
            // 
            // colDay3
            // 
            this.colDay3.HeaderText = "수";
            this.colDay3.MinimumWidth = 6;
            this.colDay3.Name = "colDay3";
            this.colDay3.Width = 125;
            // 
            // colDay4
            // 
            this.colDay4.HeaderText = "목";
            this.colDay4.MinimumWidth = 6;
            this.colDay4.Name = "colDay4";
            this.colDay4.Width = 125;
            // 
            // colDay5
            // 
            this.colDay5.HeaderText = "금";
            this.colDay5.MinimumWidth = 6;
            this.colDay5.Name = "colDay5";
            this.colDay5.Width = 125;
            // 
            // colDay6
            // 
            this.colDay6.HeaderText = "토";
            this.colDay6.MinimumWidth = 6;
            this.colDay6.Name = "colDay6";
            this.colDay6.Width = 125;
            // 
            // colDay7
            // 
            this.colDay7.HeaderText = "일";
            this.colDay7.MinimumWidth = 6;
            this.colDay7.Name = "colDay7";
            this.colDay7.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "일주일간";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 53);
            this.button2.TabIndex = 3;
            this.button2.Text = "이주일간";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblArrayCnt
            // 
            this.lblArrayCnt.AutoSize = true;
            this.lblArrayCnt.Location = new System.Drawing.Point(398, 283);
            this.lblArrayCnt.Name = "lblArrayCnt";
            this.lblArrayCnt.Size = new System.Drawing.Size(144, 19);
            this.lblArrayCnt.TabIndex = 4;
            this.lblArrayCnt.Text = "전체 자료 수 : 0";
            // 
            // array
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 383);
            this.Controls.Add(this.lblArrayCnt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "array";
            this.Text = "array";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblArrayCnt;
    }
}