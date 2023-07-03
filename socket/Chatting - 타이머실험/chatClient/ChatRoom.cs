using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace chatClient
{
    public partial class ChatRoom : Form
    {
        private Mouse _mouse;
        private string userId = string.Empty;
        private string roomName = string.Empty;
        private string userName = string.Empty;
        private ChatManager _dbManager;

        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);

        public ChatRoom(string roomId, string clientId)
        {
            InitializeComponent();
            _mouse = new Mouse(this);
            timer_list.Start();
            this.userId = clientId;
            this.roomName = roomId;

            _dbManager = new ChatManager(userId);
            this.userName = _dbManager.GetName();
            lblWelcome.Text = this.userName + "님 " + this.roomName + "에 오신 걸 환영합니다.";
        }

        public void Connect()
        {
            try
            {
                clientSocket.Connect("127.0.0.1", 9862);
                stream = clientSocket.GetStream();

                string msg = "채팅방에 접속하셨습니다.";
                DisplayText(msg);

                byte[] buffer = Encoding.Unicode.GetBytes(userName + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                byte[] roombuffer = Encoding.Unicode.GetBytes(roomName + "$");
                stream.Write(roombuffer, 0, roombuffer.Length);
                stream.Flush();

                Thread t_handler = new Thread(GetMsg);
                t_handler.IsBackground = true;
                t_handler.Start();
            }
            // 서버랑 연결 끊겼는데 클라이언트가 첫 연결 요청할 때
            catch (SocketException se)
            {
                // 중복 접속을 시도하였을 때
                if (clientSocket.Connected)
                {
                    Trace.WriteLine($"SendChat - SocketException: {se.Message}");
                    DisplayText("Error: Socket is already created");
                    MessageBox.Show("중복 접속은 금지됩니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 서버랑 연결이 끊겨있을 때
                else
                {
                    Trace.WriteLine($"SendChat - SocketException: {se.Message}");
                    DisplayText("Error: Server does not exist");
                    MessageBox.Show("서버에 접속되지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 서버랑 연결 끊겼는데 클라이언트가 또 연결 요청할 때
            catch (Exception ex)
            {
                Trace.WriteLine($"SendChat - Exception: {ex.Message}");
                DisplayText("Error: Socket is already created but Server connection lost");
                MessageBox.Show("서버에 접속되지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayText(string text)
        {
            try
            {
                if (rTxtMsg.InvokeRequired)
                {
                    rTxtMsg.BeginInvoke(new MethodInvoker(delegate { rTxtMsg.AppendText(text + Environment.NewLine); }));
                }
                else
                    rTxtMsg.AppendText(text + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void GetMsg()
        {
            while (true)
            {
                try
                {
                    stream = clientSocket.GetStream();
                    int bufSize = clientSocket.ReceiveBufferSize;
                    byte[] buffer = new byte[bufSize];
                    int size = stream.Read(buffer, 0, buffer.Length);

                    string msg = Encoding.Unicode.GetString(buffer, 0, size);

                    if (msg.StartsWith("LIST:"))
                    {
                        string listStr = msg.Substring(5); // "LIST:" 이후의 문자열 추출
                        string[] clientList = listStr.Split(','); // 클라이언트 리스트로 변환

                        listLogin.Invoke((MethodInvoker)(() =>
                        {
                            listLogin.Items.Clear(); // 기존 아이템 모두 제거
                            listLogin.Items.AddRange(clientList); // 새로운 아이템 추가
                        }));
                        continue;
                    }
                    DisplayText(msg);
                }
                // 서버 연결이 끊어지면
                catch (IOException ex)
                {
                    DisplayText("서버와의 연결이 끊어졌습니다.");
                    Console.WriteLine("Error: " + ex.Message);
                    if (clientSocket != null)
                        clientSocket.Close();
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // client 연결없이 시도했을 때
            if (stream == default(NetworkStream))
            {
                DisplayText("Error: Client connection");
                MessageBox.Show("회원님은 서버에 연결되어 있지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (stream != null && clientSocket.Connected)
            {
                byte[] buffer = Encoding.Unicode.GetBytes(this.txtMsg.Text + "$");
                try
                {
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                    txtMsg.Text = string.Empty;
                }
                // stream 객체에서 문제가 발생한 경우
                catch (ObjectDisposedException ex)
                {
                    Trace.WriteLine($"SendChat - ObjectDisposedException: {ex.Message}");
                    DisplayText("Error: STREAM");
                }
            }
            // 스트림이 없거나 연결이 끊겼을 때
            else
            {
                // 서버와 연결이 끊어졌는데 메세지를 보내려고 시도했을 때
                DisplayText("Error: Server connection");
                MessageBox.Show("서버와 연결이 끊겨있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // join에 남겨두고 다른방
        private void btnGoOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // join에서도 삭제해버리기
        private void picLogout_Click(object sender, EventArgs e)
        {
            lbLogout_Click(sender, e);
        }

        private void lbLogout_Click(object sender, EventArgs e)
        {
            int memberCnt = _dbManager.CheckMember(roomName);
            if (memberCnt > 1)
            {
                if (MessageBox.Show("채팅방에서 나가시겠습니까?", "방 탈퇴", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _dbManager.LeaveRoom(roomName);
            }
            else
            {
                if (MessageBox.Show("현재 참여자가 없습니다. 방을 삭제하고 나가시겠습니까?", "방 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dbManager.LeaveRoom(roomName);
                    _dbManager.DeleteRoom(roomName);
                }
                else
                {
                    _dbManager.LeaveRoom(roomName);
                }
            }
            this.Close();
        }

        private void timer_list_Tick(object sender, EventArgs e)
        {
            List<string> members = _dbManager.GetMember(this.roomName);
            listJoin.Items.Clear();
            listJoin.Items.AddRange(members.ToArray());
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientSocket.Connected)
            {
                stream.Close();
                clientSocket.Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (_dbManager != null)
                _dbManager.Close_Db_Connect();
        }

    }

    public class ChatManager
    {
        private DBConnect _dbConnect;
        private string _userId;
        public ChatManager(string userId)
        {
            _dbConnect = new DBConnect();
            _userId = userId;
        }
        public string GetName()
        {
            return _dbConnect.GetName(this._userId);
        }

        public string GetTime()
        {
            return _dbConnect.GetTime();
        }

        public void DeleteRoom(string roomName)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();
                string sql = "DELETE FROM CHATROOM WHERE RoomName = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", roomName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("채팅방 삭제를 실패하셨습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public void LeaveRoom(string roomName)
        {
            try
            {
                OleDbConnection conn = _dbConnect.GetConnection();
                string sql = "DELETE FROM JOINROOM WHERE RoomName = ? AND UserId = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", roomName);
                    cmd.Parameters.AddWithValue("?", this._userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("채팅방을 정상적으로 나가지 못 했습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public int CheckMember(string roomName)
        {
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT COUNT(*) FROM JOINROOM WHERE RoomName = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("?", roomName);
                object cntobj = checkCmd.ExecuteScalar();
                int cnt = 0;
                if (cntobj != null)
                    cnt = Convert.ToInt32(cntobj);
                return cnt;
            }
        }

        public List<string> GetMember(string roomName)
        {
            List<string> members = new List<string>();
            OleDbConnection conn = _dbConnect.GetConnection();

            string sql = "SELECT NickName FROM JOINROOM WHERE RoomName = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(sql, conn))
            {
                checkCmd.Parameters.AddWithValue("?", roomName);
                using (OleDbDataReader reader = checkCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string member = reader.GetString(0);
                        members.Add(member);
                    }
                }
            }
            return members;
        }

        public void Close_Db_Connect()
        {
            _dbConnect.CloseConnection();
        }
    }
}
