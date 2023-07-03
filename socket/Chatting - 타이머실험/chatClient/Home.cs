using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chatClient
{
    public partial class Home : Form
    {
        // 마우스로 폼 움직이기 위해
        private Mouse _mouse;
        // 회원디비연결
        private LoginManager _dbManager;
        // 로그인성공 이후 화면
        private ChatRoomList _chatList;

        public Home()
        {
            InitializeComponent();
            _mouse = new Mouse(this);
            _dbManager = new LoginManager();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("채팅 프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("이용해주셔서 감사합니다.");
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string  UserId  = txtId.Text;
            string  UserPwd = txtPwd.Text;
            int     isMember = 0;
            
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(UserPwd))
            {
                MessageBox.Show("정보를 다 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isMember = _dbManager.Check_Member(UserId, UserPwd);
            switch (isMember)
            {
                case 1:
                    this.Hide();
                    _chatList = new ChatRoomList(this, UserId);
                    _chatList.Show();
                    return;

                case -3:
                    if (MessageBox.Show("회원정보를 찾을 수 없습니다. 회원가입 하시겠습니까?", "로그인 실패", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        btnSignUp_Click(sender, e);
                    break;
                case -2:
                    if (MessageBox.Show("계정이 잠겨있습니다. 계정잠금을 해제하시겠습니까?", "로그인 실패", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        picUnlocked_Click(sender, e);
                    break;
                case -1:
                    if (MessageBox.Show("로그인 시도 횟수가 5회가 되어 계정이 잠겼습니다. 계정잠금을 해제하시겠습니까?", "로그인 실패", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        picUnlocked_Click(sender, e);
                    break;
                
                default:
                    MessageBox.Show("비밀번호가 틀렸습니다.", "로그인 실패");
                    break;
            }
            txtPwd.Text = string.Empty;
        }
        private void picLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.ShowDialog();
            txtId.Text = string.Empty;
            txtPwd.Text = string.Empty;
            this.Show();
        }

        private void picSignUp_Click(object sender, EventArgs e)
        {
            btnSignUp_Click(sender, e);
        }

        private void picUnlocked_Click(object sender, EventArgs e)
        {
            IdUnlock unlocked = new IdUnlock();
            unlocked.Show();
            txtPwd.Text = string.Empty;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dbManager.Close_Db_Connect();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = true;
        }

        private void picPwd_MouseLeave(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = true;
        }
        private void picPwd_MouseEnter(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = false;
        }
    }

    public class LoginManager
    {
        private DBConnect _dbConnect;

        public LoginManager()
        {
            _dbConnect = new DBConnect();
        }

        public int Check_Member(string UserId, string UserPwd)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT Password, LoginAttempts, IsLocked FROM MEMBERS WHERE UserId = ?";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("id", UserId);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string password = reader.GetString(0);
                        int loginAttempts = Convert.ToInt32(reader.GetDecimal(1));
                        int isLocked = Convert.ToInt32(reader.GetDecimal(2));

                        // 계정 잠겨있는 경우
                        if (isLocked == 1)
                        {
                            return -2;
                        }
                        // 로그인 성공
                        if (UserPwd == password)
                        {
                            sql = "UPDATE MEMBERS SET LoginAttempts = 0, IsLocked = 0 WHERE UserId = ?";
                            using (OleDbCommand updateCmd = new OleDbCommand(sql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("id", UserId);
                                updateCmd.ExecuteNonQuery();
                            }
                            return 1;
                        }
                        // 로그인 실패
                        else
                        {
                            loginAttempts++;
                            if (loginAttempts >= 5)
                            {
                                //로그인 실패 5회 이상이면 계정 잠금 처리
                                sql = "UPDATE MEMBERS SET LoginAttempts = 5, IsLocked = 1 WHERE UserId = ?";
                                using (OleDbCommand updateCmd = new OleDbCommand(sql, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("id", UserId);
                                    updateCmd.ExecuteNonQuery();
                                }
                                return -1;
                            }
                            else
                            {
                                // 로그인 실패 횟수 업데이트
                                sql = "UPDATE MEMBERS SET LoginAttempts = ? WHERE UserId = ?";
                                using (OleDbCommand updateCmd = new OleDbCommand(sql, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("attempts", loginAttempts);
                                    updateCmd.Parameters.AddWithValue("id", UserId);
                                    updateCmd.ExecuteNonQuery();
                                }
                                return 0;
                            }
                        }
                    }
                    else
                    {
                        // 입력아이디를 통해 데이터를 못 가져온 경우
                        return -3;
                    }

                }
            }
        }

        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }
}
