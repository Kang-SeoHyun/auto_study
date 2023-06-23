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

namespace tibero_test
{

    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string DbInfo = "Provider=tbprov.Tbprov.6; Location=127.0.0.1, 8629; Data Source=tibero; User ID = sys; Password=6615;"
            + "Persist Security Info = True";

            string name = txt_name.Text;
            string id = txt_id.Text;
            string pw = txt_pw.Text;
            string email = txt_email.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("정보를 다 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // dbconnection 개체 생성하여 연결 문자열 사용하여 데이터베이스 연결
            OleDbConnection conn = new OleDbConnection(DbInfo);
            conn.Open();
            try
            {
                string sql = "INSERT INTO Members (Name, UserID, Password, Email) VALUES (?, ?, ?, ?)";
                // 연결 성공적이면 OleDbCommand 개체로 sql쿼리 실행하고 결과처리 가능
                OleDbCommand cmd = new OleDbCommand(sql);
                cmd.Connection = conn;
                // 값 넣기!
                cmd.Parameters.AddWithValue ("Name", name);
                cmd.Parameters.AddWithValue ("UserID", id);
                cmd.Parameters.AddWithValue ("Password", pw);
                cmd.Parameters.AddWithValue ("Email", email);
                
                // 이게 sql문 실행하는 것임.
                // cmd.ExecuteNonQuery();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("hello 반갑습니당.", "가입완료");
                    conn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("헉 회원되기 실패ㅜㅜ", "가입실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "물어보는것임", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }
    }
}
