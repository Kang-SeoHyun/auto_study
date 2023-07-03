using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chatClient
{
    public partial class IdCheck : Form
    {
        private Mouse _mouse;

        private CheckIdManager _dbManager;
        public string EnteredId { get; private set; }
        public IdCheck()
        {
            _dbManager = new CheckIdManager();
            InitializeComponent();

            _mouse = new Mouse(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int count = _dbManager.Check_Id(txtId.Text);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("아이디를 적어주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (count > 0)
                MessageBox.Show("아이디가 또 중복됩니다.", "아이디 중복", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                EnteredId = txtId.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            return;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dbManager.Close_Db_Connect();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "아이디 중복확인 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("취소하시겠습니까?", "아이디 중복확인 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                this.Close();
        }
    }

    public class CheckIdManager
    {
        private DBConnect _dbConnect;

        public CheckIdManager()
        {
            _dbConnect = new DBConnect();
        }

        public int Check_Id(string id)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT COUNT(*) FROM MEMBERS WHERE UserId = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("p1", id);

                object countobj = checkCmd.ExecuteScalar();
                int count = 0;
                if (countobj != null)
                {
                    count = Convert.ToInt32(countobj);
                }
                return count;
            }
        }

        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }
}
