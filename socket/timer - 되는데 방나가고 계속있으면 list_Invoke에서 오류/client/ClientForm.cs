using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace client
{
    public partial class ClientForm : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string msg = string.Empty;
        string userName = string.Empty;
        string regName = string.Empty;
        string roomName = string.Empty;

        public ClientForm(string regName, string roomName, string guest)
        {
            InitializeComponent();
            this.userName = guest;
            this.regName = regName;
            this.roomName = roomName;
            label1.Text = userName + "님 " + roomName + "에 오신 걸 환영합니다.";
        }

        public void Connect()
        {
            try
            {
                clientSocket.Connect("127.0.0.1", 9862);
                stream = clientSocket.GetStream();

                msg = "Connected to Chat Server";
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

        private void DisplayText(string text)
        {
            try
            {
                if (richTextBox1.InvokeRequired)
                {
                    richTextBox1.BeginInvoke(new MethodInvoker(delegate { richTextBox1.AppendText(text + Environment.NewLine); }));
                }
                else
                    richTextBox1.AppendText(text + Environment.NewLine);
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

                        listBox1.Invoke((MethodInvoker)(() =>
                        {
                            listBox1.Items.Clear(); // 기존 아이템 모두 제거
                            listBox1.Items.AddRange(clientList); // 새로운 아이템 추가
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
        private void client_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientSocket != null)
            {
                SendClientExit();
                clientSocket.Close();
            }
        }

        private void SendClientExit()
        {
            string exitMsg = userName + "님이 퇴장하셨습니다.";
            byte[] buffer = Encoding.Unicode.GetBytes(exitMsg + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

    }
}