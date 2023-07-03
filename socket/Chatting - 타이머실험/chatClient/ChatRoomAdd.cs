using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace chatClient
{
    public partial class ChatRoomAdd : Form
    {
        private Mouse _mouse;
        private RoomAddManager _dbManager;
        
        public ChatRoomAdd(string UserId)
        {
            InitializeComponent();
            _mouse = new Mouse(this);
            _dbManager = new RoomAddManager(UserId);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string roomName = txtRoom.Text;

            if (string.IsNullOrEmpty(roomName))
            {
                MessageBox.Show("생성하실 방 이름을 적어주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int isRoom = _dbManager.CheckRoom(roomName);
            if (isRoom > 0)
                return;
            else if (isRoom == -1)
                this.Close();
            else
            {
                _dbManager.AddRoom(roomName);
                _dbManager.JoinRoom(roomName);
                this.Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (_dbManager != null)
                _dbManager.Close_Db_Connect();
        }
    }

    public class RoomAddManager
    {
        private DBConnect _dbConnect;
        private string UserId;
        public RoomAddManager(string clientId)
        {
            _dbConnect = new DBConnect();
            this.UserId = clientId;
        }

        public int CheckRoom(string roomName)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT COUNT(*) FROM CHATROOM WHERE RoomName = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("?", roomName);
                object cntobj = checkCmd.ExecuteScalar();
                int cnt = 0;
                if (cntobj != null)
                    cnt = Convert.ToInt32(cntobj);
                if (cnt > 0)
                {
                    if (MessageBox.Show("이미 존재하는 방 입니다. 추가를 중지하겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return -1;
                    return cnt;
                }
                return 0;
            }
        }
        public void AddRoom(string roomName)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();

                string sql = "INSERT INTO CHATROOM (RoomName, RegId) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", roomName);
                    cmd.Parameters.AddWithValue("?", this.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("채팅방 생성에 실패하였습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public void JoinRoom(string roomName)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();
                string sql = "INSERT INTO JOINROOM (UserId, RoomName, NickName) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", this.UserId);
                    cmd.Parameters.AddWithValue("?", roomName);
                    cmd.Parameters.AddWithValue("?", _dbConnect.GetName(this.UserId));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("채팅방 추가와 접속을 성공하였습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("채팅방 추가는 되었으나 접속에 실패하였습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex.Message);
            }
        }

        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }

}

