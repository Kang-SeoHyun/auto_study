using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class client_form : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string msg = string.Empty;
        public client_form()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            clientSocket.Connect("127.0.0.1", 9862);
            stream = clientSocket.GetStream();

            msg = "Connected to Chat Server";
            DisplayText(msg);

            byte[] buffer = Encoding.Unicode.GetBytes(this.txtName.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread t_handler = new Thread(GetMsg);
            t_handler.IsBackground = true;
            t_handler.Start();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (stream != null && clientSocket.Connected)
            {
                byte[] buffer = Encoding.Unicode.GetBytes(this.txtMsg.Text + "$");
                try
                {
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                    txtMsg.Text = string.Empty;
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    DisplayText("Error: " + ex.Message);
                }
            }
            else
            {
                // 서버 종료했는데 클라이언트에서 메세지 보내려고 시도했을 때
                MessageBox.Show("서버와의 연결이 끊어졌습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new MethodInvoker(delegate { richTextBox1.AppendText(text + Environment.NewLine); }));
            }
            else
                richTextBox1.AppendText(text + Environment.NewLine);
        }
        private void GetMsg()
        {
            while (true)
            {
                try
                {
                    stream = clientSocket.GetStream();
                    int bfrSize = clientSocket.ReceiveBufferSize;
                    byte[] buffer = new byte[bfrSize];
                    int size = stream.Read(buffer, 0, buffer.Length);

                    string msg = Encoding.Unicode.GetString(buffer, 0, size);
                    DisplayText(msg);
                }
                catch (IOException ex)
                {
                    DisplayText("서버와의 연결이 끊어졌습니다.");
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
            string exitMsg = this.txtName.Text + "님이 퇴장하셨습니다.";
            byte[] buffer = Encoding.Unicode.GetBytes(exitMsg + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
    }
}
