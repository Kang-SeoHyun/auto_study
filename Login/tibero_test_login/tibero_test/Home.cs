using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tibero.DbAccess;
using System.Data.OleDb;
using System.Net.Security;

namespace tibero_test
{
    public partial class Home : Form
    {
        private LoginManager loginManager;
        // ChatList 객체 선언
        private ChatList chatList; 
        public Home()
        {
            loginManager = new LoginManager();
            InitializeComponent();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Form signUp = new SignUp();
            // 일단 이 창 숨겨
            this.Hide();
            // 새 폼에서 클릭 가능함
            // SignIn.Show();
            // 회원가입 폼에서 다른곳으로 안 움직이길 원하므로
            signUp.ShowDialog();
            txt_id.Text = string.Empty;
            txt_pw.Text = string.Empty;
            this.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string user_id = txt_id.Text;
            string password = txt_pw.Text;

            int isMember = loginManager.Check_Member(user_id, password);

            // 데이터 베이스에 있는 사람이면
            if (isMember == 1)
            {
                MessageBox.Show("채팅하러 가보실까나", "로그인 성공");
                chatList = new ChatList(this);
                chatList.Show();
                this.Hide();
                return;
            }
            else if (isMember == -1)
            {
                MessageBox.Show("5번이나 틀려?! 수상하네 빠이.", "로그인 실패");
                // 어떻게 제어할지 정하기 - 뭐 계정잠금이나 로그인 못하게하기 그런거?
            }
            else
                MessageBox.Show("아이디나 비밀번호 틀렸습니다.", "로그인 실패");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            loginManager.Close_Db_Connect();
        }
    }

    public class LoginManager
    {
        private OleDbConnection conn;
        private int loginFail;

        public LoginManager()
        {
            // 연결 정보
            string DbInfo = "Provider=tbprov.Tbprov.6; Location=127.0.0.1, 8629; Data Source=tibero; User ID = sys; Password=6615;"
            + "Persist Security Info = True";

            // 연결 시킴
            conn = new OleDbConnection(DbInfo);
            conn.Open();
        }

        // 성공하면 1, 실패하면 0, 5번 틀리면 -1
        public int Check_Member(string user_id, string password)
        {
            loginFail++;
            string sql = "SELECT COUNT(*) FROM MEMBERS WHERE USERID = ? AND PASSWORD = ?";

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Connection = conn;
            // 값 넣기!
            cmd.Parameters.AddWithValue("id", user_id);
            cmd.Parameters.AddWithValue("pw", password);
            // 저 cmd.ExcuteSccalar는 리턴값이 object형식이라 (int) 안됨!
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                loginFail = 0;
                return 1;
            }
            else
            {
                if (loginFail >= 5)
                {
                    // 계정 잠금이나 그런거 ㄱ
                    loginFail = 0;
                    return -1;
                }
                return 0;
            }
        }
        public void Close_Db_Connect()
        {
            conn.Close();
        }

    }
}
