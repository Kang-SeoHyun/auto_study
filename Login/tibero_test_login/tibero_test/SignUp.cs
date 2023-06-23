using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 이런걸 네임스페이스라고 함
using Tibero.DbAccess;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace tibero_test
{

    public partial class SignUp : Form
    {
        private SignUpManager SignUpManager;
        public SignUp()
        {
            SignUpManager = new SignUpManager();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string id = txt_id.Text;
            string pw = txt_pw.Text;
            string email = txt_email.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("정보를 다 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int isJoin = SignUpManager.Join_Member(name, id, pw, email);
            if (isJoin > 0)
            {
                MessageBox.Show("hello 반갑습니당.", "가입완료");
                this.Close();
            }
            else
                MessageBox.Show("헉 회원되기 실패ㅜㅜ", "가입실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "물어보는것임", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            SignUpManager.Close_Db_Connect();
        }
    }

    public class SignUpManager
    {
        private OleDbConnection conn;

        public SignUpManager()
        {
            string DbInfo = "Provider=tbprov.Tbprov.6; Location=127.0.0.1, 8629; Data Source=tibero; User ID = sys; Password=6615;"
            + "Persist Security Info = True";

            conn = new OleDbConnection(DbInfo);
            conn.Open();
            //if(!IsTableDataExists("Members"))
            //    CreateMembersTable();
        }
        public int Join_Member(string name, string id, string pw, string email)
        {
            string sql = "INSERT INTO Members (Name, UserID, Password, Email) VALUES (?, ?, ?, ?)";
            // 연결 성공적이면 OleDbCommand 개체로 sql쿼리 실행하고 결과처리 가능
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Connection = conn;
            // 값 넣기!
            cmd.Parameters.AddWithValue("p1", name);
            cmd.Parameters.AddWithValue("p2", id);
            cmd.Parameters.AddWithValue("p3", pw);
            cmd.Parameters.AddWithValue("p4", email);

            return ((int)cmd.ExecuteNonQuery());
        }
        public void Close_Db_Connect()
        {
            conn.Close();
        }
        //private int IsTableDataExists(string tableName)
        //{
        //    string sql = "SELECT COUNT(*) FROM Members";
        //    OleDbCommand cmd = new OleDbCommand(sql, conn);

        //    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //    return count;
        //}
        //private void DropSequence(string sequenceName)
        //{
        //    string sql = $"DROP SEQUENCE {sequenceName}";

        //    OleDbCommand cmd = new OleDbCommand(sql);
        //    cmd.Connection = conn;
        //    cmd.ExecuteNonQuery();
        //}
        //private void CreateMembersSeq()
        //{
        //    string sql = "CREATE SEQUENCE MembersSeq";
        //    OleDbCommand cmd = new OleDbCommand(sql);
        //    cmd.Connection = conn;
        //    cmd.ExecuteNonQuery();
        //}

        //private void CreateMembersTable()
        //{
        //    DropSequence("MEMBERSSEQ");
        //    CreateMembersSeq();
        //    string sql = "CREATE TABLE Members(ID NUMBER DEFAULT MembersSeq.NEXTVAL NOT NULL, NAME VARCHAR2(30) NOT NULL, USERID VARCHAR2(30) NOT NULL, PASSWORD VARCHAR2(30) NOT NULL, EMAIL VARCHAR2(50) NOT NULL) NOLOGGING";
        //    OleDbCommand cmd = new OleDbCommand(sql, conn);
        //    cmd.ExecuteNonQuery();

        //}

    }
}
