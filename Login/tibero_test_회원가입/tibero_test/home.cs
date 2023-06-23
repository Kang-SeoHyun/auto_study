using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tibero_test
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Form SignUp = new SignUp();
            // 일단 이 창 숨겨
            this.Hide();
            // 새 폼에서 클릭 가능함
            // SignIn.Show();
            // 회원가입 폼에서 다른곳으로 안 움직이길 원하므로
            SignUp.ShowDialog();
            txt_id.Text = string.Empty;
            txt_pw.Text = string.Empty;
            this.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            // if 데이터 베이스에 없는 사람이면
            // {
            //      MessageBox.Show("아이디나 비밀번호 틀렸습니다.", "에러");
            // }
            this.Close();
        }
    }
}
