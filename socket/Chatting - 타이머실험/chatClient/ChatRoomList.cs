using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chatClient
{
    public partial class ChatRoomList : Form
    {
        // 마우스로 폼 움직이기 위해
        private Mouse _mouse;

        // 이전 Home 폼을 저장하기 위한 변수
        private Home _home;
        private ChatListManager _dbManager;
        private ChatRoomAdd _chatRoomAdd;
        private string _userId;

        public ChatRoomList(Home home, string ClientId)
        {
            InitializeComponent();
            timerTime.Start();
            this._home = home;
            this._userId = ClientId;
            _mouse = new Mouse(this);
            _dbManager = new ChatListManager(_userId);
            lblName.Text = _dbManager.GetName() + "님 안녕하세요.";
        }

        protected override void OnClosed(EventArgs e)
        {
            _home.Show();
            base.OnClosed(e);
            if (_dbManager != null)
                _dbManager.Close_Db_Connect();
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            lbLogout_Click(sender, e);
        }

        private void lbLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "이름을 입력하세요.")
            {
                txtName.Text = "";
                txtName.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "이름을 입력하세요.";
                txtName.ForeColor = SystemColors.WindowFrame;
            }
        }

        private void picChatAdd_Click(object sender, EventArgs e)
        {
            _chatRoomAdd = new ChatRoomAdd(this._userId);
            _chatRoomAdd.ShowDialog();
            picUpdate_Click(sender, e);
        }

        private void picMyRoom_Click(object sender, EventArgs e)
        {
            afterUpdateTime = DateTime.Now;
            timerUpdate.Start();
            lblMode.Text = "내 채팅방";
            _dbManager.LoadMyData(this.listView, this._userId);
        }

        private void picAllRoom_Click(object sender, EventArgs e)
        {
            afterUpdateTime = DateTime.Now;
            timerUpdate.Start();
            lblMode.Text = "전체 채팅방";
            _dbManager.LoadAllData(this.listView);
        }

        private void ChatRoomList_Load(object sender, EventArgs e)
        {
            _dbManager.LoadAllData(this.listView);
        }

        private void picChatJoin_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count == 1)
            {
                string roomName = listView.SelectedItems[0].SubItems[0].Text;
                ChatRoom room = new ChatRoom(roomName, this._userId);
                // 처음 접속하면 내 방에 추가해주기
                int isJoin = _dbManager.CheckJoin(roomName);
                if (isJoin == 0)
                    _dbManager.JoinRoom(roomName);
                // 이거 connect랑 show순서도 중요함!
                room.Connect();
                room.Show();
            }
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = _dbManager.GetTime();
        }

        private DateTime afterUpdateTime; 
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (afterUpdateTime != DateTime.MinValue)
            {
                TimeSpan clkT = DateTime.Now - afterUpdateTime;
                this.lblUpdate.Text = string.Format("{0:D2}:{1:D2}", (int)clkT.TotalMinutes, clkT.Seconds);
            }
        }

        private void picUpdate_Click(object sender, EventArgs e)
        {
            afterUpdateTime = DateTime.Now;
            timerUpdate.Start();
            if (lblMode.Text == "내 채팅방")
                _dbManager.LoadMyData(this.listView, this._userId);
            else
                _dbManager.LoadAllData(this.listView);
        }
    }

    public class ChatListManager
    {
        private DBConnect _dbConnect;
        private string _userId;

        public ChatListManager(string userId)
        {
            _dbConnect = new DBConnect();
            _userId = userId;
        }

        public string GetName()
        {
            return _dbConnect.GetName(_userId);
        }

        public string GetTime()
        {
            return _dbConnect.GetTime();
        }
        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }

        public void LoadAllData(ListView listView)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();

                string sql = "SELECT c.RoomName, NVL(LISTAGG(j.UserId, ',') WITHIN GROUP(ORDER BY j.UserId), ' ') AS JoinIds " +
                             "FROM CHATROOM c " +
                             "LEFT JOIN JOINROOM j ON c.RoomName = j.RoomName " +
                             "GROUP BY c.RoomName, c.RegTime " +
                             "ORDER BY c.RegTime DESC";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        listView.Items.Clear();

                        while (reader.Read())
                        {
                            string roomName = reader.GetString(0);
                            string regId = reader.GetString(1);

                            var item = new ListViewItem(new string[3] { roomName, "모", regId });
                            listView.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void LoadMyData(ListView listView, string UserId)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();

                string sql = "SELECT c.RoomName, LISTAGG(j.UserId, ',') WITHIN GROUP(ORDER BY j.UserId) AS JoinIds  " +
                            "FROM JOINROOM j " +
                            "JOIN CHATROOM c ON j.RoomName = c.RoomName " +
                            "GROUP BY c.RoomName, c.RegTime " +
                            "ORDER BY c.RegTime DESC";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", UserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        listView.Items.Clear();

                        while (reader.Read())
                        {
                            string roomName = reader.GetString(0);
                            string regId = reader.GetString(1);

                            if (regId.Contains(UserId))
                            {
                                var item = new ListViewItem(new[] { roomName, "모", regId });
                                listView.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public int CheckJoin(string roomName)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT COUNT(*) FROM JOINROOM WHERE UserId = ? AND RoomName = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("?", _userId);
                checkCmd.Parameters.AddWithValue("?", roomName);
                object cntobj = checkCmd.ExecuteScalar();
                int cnt = 0;
                if (cntobj != null)
                    cnt = Convert.ToInt32(cntobj);
                if (cnt > 0)
                    return cnt;
                else
                    return 0;
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
                    cmd.Parameters.AddWithValue("?", this._userId);
                    cmd.Parameters.AddWithValue("?", roomName);
                    cmd.Parameters.AddWithValue("?", _dbConnect.GetName(this._userId));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("채팅방 접속에 실패하였습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
