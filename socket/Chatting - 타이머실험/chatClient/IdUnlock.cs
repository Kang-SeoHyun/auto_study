using System;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;

namespace chatClient
{
    public partial class IdUnlock : Form
    {
        private Mouse _mouse;
        private UnlockedManager _dbManager;
        public IdUnlock()
        {
            InitializeComponent();
            _mouse = new Mouse(this);
            _dbManager = new UnlockedManager();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "계정 잠금해제 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "계정 잠금해제 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                MessageBox.Show("정보를 다 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int isMember = _dbManager.Check_Member(id, name);
            if (isMember == 1)
            {
                if (MessageBox.Show("계정잠금을 해제하고 비밀번호를 0000으로 초기화합니다.", "잠금해제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _dbManager.unlocked(id);
                this.Close();
            }
            else if (isMember == 0)
            {
                MessageBox.Show("계정이 잠겨있지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("아이디와 이름이 일치하지 않습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dbManager.Close_Db_Connect();
        }
    }

    public class UnlockedManager
    {
        private DBConnect _dbConnect;
        public UnlockedManager()
        {
            _dbConnect = new DBConnect();
        }

        public int Check_Member(string UserId, string UserName)
        {
            OleDbConnection conn = _dbConnect.GetConnection();
            string sql = "SELECT COUNT(*) FROM MEMBERS WHERE USERID = ? AND UserName = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                // 값 넣기!
                checkCmd.Parameters.AddWithValue("id", UserId);
                checkCmd.Parameters.AddWithValue("name", UserName);
                // 저 cmd.ExcuteSccalar는 리턴값이 object형식이라 (int) 안됨!
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count <= 0)
                    return -1;
            }

            sql = "SELECT IsLocked FROM MEMBERS WHERE USERID = ?";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn)) 
            {
                cmd.Parameters.AddWithValue("id", UserId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                    return 1;
                else
                    return 0;
            }
        }
        public void unlocked(string UserId)
        {
            OleDbConnection conn = _dbConnect.GetConnection();
            string sql = "UPDATE MEMBERS SET LoginAttempts = 0, IsLocked = 0, Password = '0000' WHERE UserId = ?";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("id", UserId);
                cmd.ExecuteNonQuery();
            }
        }
        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }
}
