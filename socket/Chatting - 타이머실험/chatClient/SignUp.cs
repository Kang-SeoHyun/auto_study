using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chatClient
{
    public partial class SignUp : Form
    {
        private Mouse _mouse;
        private SignUpManager _dbManager;

        public SignUp()
        {
            InitializeComponent();
            _mouse = new Mouse(this);
            _dbManager = new SignUpManager();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtId.Text;
            string pw = txtPwd.Text;
            string team = cboxTeam.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(team))
            {
                MessageBox.Show("정보를 다 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int isJoin = _dbManager.Join_Member(name, id, pw, team);
            if (isJoin > 0)
            {
                // insert 성공했을 때 == 보통 1 반환됨
                txtId.Text = _dbManager.EnteredId;
                MessageBox.Show("회원가입 성공했습니다.", "가입완료");
                this.Close();
            }
            else if (isJoin == -1)
            {
                txtId.Text = string.Empty;
            }
            else
            {
                // 디비 문제등으로 실패했을 때
                txtId.Text = string.Empty;
                MessageBox.Show("회원가입 실패했습니다.", "가입실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "회원가입 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dbManager.Close_Db_Connect();
        }
    }
    public class SignUpManager
    {
        private DBConnect _dbConnect;
        public string EnteredId { get; private set; }
        public SignUpManager()
        {
            _dbConnect = new DBConnect();
        }

        public int Join_Member(string name, string id, string pw, string team)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT COUNT(*) FROM MEMBERS WHERE UserId = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("p1", id);

                // 아이디 중복 확인하고 처리해주기.
                object countobj = checkCmd.ExecuteScalar();
                int count = 0;
                if (countobj != null)
                {
                    count = Convert.ToInt32(countobj);
                }
                if (count > 0)
                {
                    IdCheck checkId = new IdCheck();
                    // 중복폼에서 확인 눌렀을 시
                    if (checkId.ShowDialog() == DialogResult.OK)
                    {
                        id = checkId.EnteredId;
                        EnteredId = checkId.EnteredId;
                    }
                    else
                        return -1;
                    if (MessageBox.Show("입력하신 아이디로 회원가입 진행하시겠습니까?", "회원가입 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return -1;
                }
            }
            
            sql = "INSERT INTO MEMBERS (UserId, Password, UserName, TeamName, IsLocked, LoginAttempts) VALUES (?, ?, ?, ?, 0, 0)";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", pw);
                cmd.Parameters.AddWithValue("p3", name);
                cmd.Parameters.AddWithValue("p4", team);

                return ((int)cmd.ExecuteNonQuery());
            }
        }
        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }
}